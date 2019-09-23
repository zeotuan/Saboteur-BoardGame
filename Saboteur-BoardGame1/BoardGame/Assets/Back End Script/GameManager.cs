using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameManager : Singleton<GameManager>
{
    //public static GameManager Instance { get; private set; }
    public GameObject PlayerPrefab;
    public GameObject RoundPrefab;
    public List<GameObject> Players;
    public List<GameObject> PassedRounds;
    public GameObject currentRound;
    public GameObject deck;
    public GameObject deckPrefab;
    //StateMachine stateMachine = new StateMachine();
    private bool gameStarted;
    
   
    
    void Awake()
    {
        base.Awake();
        
        for(int i = 0; i < 6; i++)// innitate 7 player
        {
            createPlayer();
        }       
        gameStarted = false;
    }
    void Start()
    {
        deck = Instantiate(deckPrefab) as GameObject;
        deck.transform.SetParent(transform);
        if (!gameStarted)
        {
            currentRound = createRound();   
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
        currentRound.GetComponent<Round>().enabled = false;
        PassedRounds.Add(currentRound);
        currentRound = createRound();
        deck.GetComponent<Deck>().GenerateDeck(10);
    }
    
    

    bool checkWinCondition()
    {
        return false;
    }

    public GameObject createRound()
    {
        GameObject round = Instantiate(RoundPrefab) as GameObject;
        round.transform.SetParent(transform);
        return round;

    }

    public void createPlayer()
    {
        GameObject player = Instantiate(PlayerPrefab) as GameObject;
        PlayerController playerDetail = player.GetComponent<PlayerController>();
        player.transform.SetParent(transform);
        Players.Add(player);
    }
   

    
}
