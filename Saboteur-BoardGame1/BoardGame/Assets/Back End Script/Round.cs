﻿using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{
    bool RoundStarted;
    public int Turn;
    
    bool roundEnd = false;
    [SerializeField]
    float TimeLeft = 10;
    [SerializeField]
    string[] roles;
    

    void Start()
    {
        shufflePlayer();
        shuffleRole();
        /*GameManager.Instance.shuffle(roles);
        GameManager.Instance.shuffle(GameManager.Instance.Players);*/
        
        if (!RoundStarted)
        {
            Turn = 0;
            int count = 0;
            for(int i = 0; i < 5; i++){//deal 5 card to each player when starting the round
                foreach(GameObject player in GameManager.Instance.Players)
                {
                    GameManager.Instance.Deck.Deal(player.GetComponent<PlayerController>());
                }
            }
            foreach (GameObject player in GameManager.Instance.Players)
            {
                PlayerController playerC = player.GetComponent<PlayerController>();
                playerC.setRole(roles[count]);
                playerC.addRole(roles[count]);
                playerC.PickAxe = true;
                playerC.Lamb = true;
                playerC.Cart = true;
                foreach (GameObject card in playerC.hand)
                {
                    card.GetComponent<activate>().enabled = false;
                    card.SetActive(false);
                }

                count++;
            }

            GetCurPlayer().GetComponent<PlayerController>().StartTurn();
            raiseCover();
        }
        GameObject Canvas = GameObject.Find("Canvas");
        //Canvas.transform.Find("Panel/Bottom_Left/Player's panel/Player's name").GetComponent<Text>().text = currentPlayer.name;
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        GameObject.Find("Time left").GetComponent<Time_Record>().time = TimeLeft;
        if(TimeLeft <= 10)
        {
            
        }
        if(TimeLeft <= 0)//out of time without playing anycard
        {
                int index = Random.Range(0, GetCurPlayer().hand.Count);
            GetCurPlayer().Discard(GetCurPlayer().hand[index]);
               
               
        }
        if (GetCurPlayer().Played())
        {
            SwitchTurn();
        }   

    }
    

    public void StartRound()
    {
        Turn = 0;
    }

    public void  setTimeLeft(float x)
    {
        TimeLeft = x;
    }

    public void SwitchTurn()
    {
   
        GameObject PlayersPanel = GameObject.Find("Canvas/Panel/Left");
        Debug.Log(PlayersPanel.transform.name);
       
        for (int i = 0; i < PlayersPanel.transform.childCount; i++)
        {
            PlayersPanel.transform.GetChild(i).Find("Select").gameObject.SetActive(false);
            PlayersPanel.transform.GetChild(i).Find("Role_assump").gameObject.SetActive(false);
        }

        TimeLeft = 60;
        RoundStarted = true;
        GameManager.Instance.Deck.Deal(GetCurPlayer().GetComponent<PlayerController>());
        GetCurPlayer().EndTurn();
        int Condition = checkWinCondition();
        Debug.Log(Condition);
        if (Condition == 1 || Condition == -1)//someone win
        {
            //activate the end game panel
            GameObject End_Game = GameObject.Find("Canvas/Panel/End Game");
            End_Game.SetActive(true);
            
            CalculateReward(Condition);
            EndRound();
            return;
        }
        Turn++;
        if (Turn == GameManager.Instance.Players.Count)
        {
            Turn = 0;    
        }
        GetCurPlayer().StartTurn();

        raiseCover();
        
    }
    public PlayerController GetCurPlayer(){
        return GameManager.Instance.Players[Turn].GetComponent<PlayerController>();
    }

    int checkWinCondition()
    {
        Board board = GameObject.Find("Map").GetComponent<Board>();
        int WinStatus = 0;
        if(board.BreadthFirstSearch(2, 0))// if there is a path from start to goal
        {
            WinStatus = 1;//Goal digger win
        }
        else//there is no path from start to goal
        {
            if (GameManager.Instance.Deck.deck.Count == 0)//there no card left 
            {
                bool cardleft = false;
                foreach(GameObject p in GameManager.Instance.Players)
                {
                    if (p.GetComponent<PlayerController>().hand.Count > 0)
                    {
                        cardleft = true;
                    }
                }
                if(!cardleft)
                    WinStatus = -1;//saboteur win
            }  
        }
        return WinStatus;// no group has wo
    }

    public void EndRound()
    {
        roundEnd = true;
    }

    
    void shufflePlayer()
    {
        for (int i = 0; i < GameManager.Instance.Players.Count; i++)
        {
            var container = GameManager.Instance.Players[i];
            int randomIndex = Random.Range(i, GameManager.Instance.Players.Count);
            GameManager.Instance.Players[i] = GameManager.Instance.Players[randomIndex];
            GameManager.Instance.Players[randomIndex] = container;
        }
    }

    void shuffleRole()
    {
        for (int i = 0; i < roles.Length; i++)
        {
            var container = roles[i];
            int randomIndex = Random.Range(i, roles.Length);
            roles[i] = roles[randomIndex];
            roles[randomIndex] = container;
        }
    }

    void raiseCover()
    {
        GameObject Canvas = GameObject.Find("Canvas");
        //Canvas.transform.Find("Panel/Bottom_Left/Player's panel/Player's name").GetComponent<Text>().text = currentPlayer.name;
        Canvas.transform.Find("Panel/Cover").gameObject.SetActive(true);
        
    }

    void CalculateReward(int WinnerCode){
        string winner;
        if(WinnerCode == 0){
            return;
        }else if (WinnerCode == 1){
            winner = "dwarf";
        }else{
            winner = "saboteur";
        }
        foreach(GameObject p in GameManager.Instance.Players)
        {
            PlayerController player = p.GetComponent<PlayerController>();
            if (player.getRole() == winner)
            {
                player.addPoint(Random.Range(1,3));
            }else{
                player.addPoint(0);
            }
        }
    }
}
