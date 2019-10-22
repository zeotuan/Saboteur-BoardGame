using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]
public class GameManager : Singleton<GameManager>
{
    //public static GameManager Instance { get; private set; }
    public GameObject PlayerPrefab;
    public GameObject RoundPrefab;
    public List<GameObject> Players;
    public List<GameObject> PassedRounds;
    public GameObject currentRound;//should be replaced
    public Round currRound;
    public GameObject deck;
    public Deck Deck;
    public Board Board;
    public GameObject deckPrefab;
    //StateMachine stateMachine = new StateMachine();
    private bool gameStarted;
    [SerializeField]
    int maxRound;
    [SerializeField]
    int curRound;
    private int playerCount;
    private String[] playerNames;
    


    void Awake()
    {
        base.Awake(); 
    }
    void Start()
    {
        
    }
    void Update()
    {
        //stateMachine.Update();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //QuitGamePanel.gameObject.SetActive(true);
        }

            
    }

    public void StartGame(){

        for(int i = 0; i < playerCount; i++)// innitate 7 player
        {
            createPlayer(playerNames[i]);
        }       
        gameStarted = false;
        Board = GameObject.Find("Map").GetComponent<Board>();


        deck = Instantiate(deckPrefab) as GameObject;
        deck.transform.SetParent(transform);
        Deck = deck.GetComponent<Deck>();
        if (!gameStarted)
        {
            currentRound = createRound();   
            currentRound.GetComponent<Round>().StartRound();
        }
    }

    public void setPlayerCount(int num){
        playerCount = num;
    }

    public void setMaxRound(int num){
        maxRound = num;
    }

    public void setPlayerNames(String[] name){
        playerNames = name;
    }

    public void SwitchRound()
    {
       
        curRound++;
        if(curRound < maxRound){
            gameStarted = true;
            currRound.EndRound();
            currRound.enabled = false;
            PassedRounds.Add(currentRound);
            currentRound = createRound();
            Deck.GenerateDeck(10);
            Board.GenerateBoard(5, 9, 5);
        }else{
            //Raise Score Board
        }               

        
    }

    bool checkWinCondition()
    {
        return false;
    }

    public GameObject createRound()
    {
        GameObject round = Instantiate(RoundPrefab) as GameObject;
        round.transform.SetParent(transform);
        currRound = round.GetComponent<Round>();
        return round;

    }

    public void createPlayer(String name)
    {
        GameObject player = Instantiate(PlayerPrefab) as GameObject;
        player.transform.SetParent(transform);
        Players.Add(player);
        player.GetComponent<PlayerController>().playerName = name ;
        //Ryan's
         
    }
    //generic function to create GameObject and add Parent to it 
    public GameObject createGameObject(GameObject Prefab, Transform Parent)
    {
        GameObject obj = Instantiate(Prefab) as GameObject;
        obj.transform.SetParent(Parent);
        return obj;
    }

    public void shuffle(object list)
    {
        int count = ((IList)list).Count;
        for (int i = 0; i < count; i++)
        {
            var container = ((IList)list)[i];
            int randomIndex = UnityEngine.Random.Range(i, count);
            ((IList)list)[i] = ((IList)list)[randomIndex];
            ((IList)list)[randomIndex] = container;
        }
    }
}
