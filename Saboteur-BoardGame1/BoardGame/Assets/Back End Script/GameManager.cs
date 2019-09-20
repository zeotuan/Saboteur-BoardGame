using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameManager : Singleton<GameManager>
{
    //public static GameManager Instance { get; private set; }
    public GameObject PlayerPrefab;
    public GameObject RoundPrefab;
    public int RoundTurn;
    public List<GameObject> Players;
    public List<GameObject> Rounds;
    public GameObject currentRound { get { return Rounds[RoundTurn]; } }

    //StateMachine stateMachine = new StateMachine();
    private bool gameStarted;
    
   
    
    void Awake()
    {
        base.Awake();
        
        for(int i = 0; i < 6; i++)// innitate 7 player
        {
            createPlayer();
        }
        for(int i =0; i < 4; i++)// initiate 5 round 
        {
            createRound();
        }
        gameStarted = false;
    }
    void Start()
    {
        if (!gameStarted)
        {
            RoundTurn = 0;
            currentRound.GetComponent<Round>().StartRound();
        }
    }
    void Update()
    {
        //stateMachine.Update();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //QuitGamePanel.gameObject.SetActive(true);
        }

            
    }

    public void SwitchRound()
    {
        gameStarted = true;
        currentRound.GetComponent<Round>().EndRound();
        RoundTurn++;
        if (RoundTurn < Rounds.Count)
        {
            currentRound.GetComponent<Round>().StartRound();
        }
        else
        {
            Debug.Log("Last round ended");
        }
    }
    
    

    bool checkWinCondition()
    {
        return false;
    }

    public void createRound()
    {
        GameObject round = Instantiate(RoundPrefab) as GameObject;
        round.transform.SetParent(transform);
        Rounds.Add(round);
    }

    public void createPlayer()
    {
        GameObject player = Instantiate(PlayerPrefab) as GameObject;
        PlayerController playerDetail = player.GetComponent<PlayerController>();
        player.transform.SetParent(transform);
        Players.Add(player);
    }
   

    
}
