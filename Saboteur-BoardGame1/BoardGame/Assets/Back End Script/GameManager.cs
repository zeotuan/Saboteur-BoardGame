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
    public GameObject currentRound;
    public GameObject deck;
    public GameObject deckPrefab;
    //StateMachine stateMachine = new StateMachine();
    private bool gameStarted;
    [SerializeField]
    int maxRound;
    [SerializeField]
    int curRound;
    
   
    
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
        curRound++;
        if(curRound < maxRound){
            gameStarted = true;
            currentRound.GetComponent<Round>().EndRound();
            currentRound.GetComponent<Round>().enabled = false;
            PassedRounds.Add(currentRound);
            currentRound = createRound();
            deck.GetComponent<Deck>().GenerateDeck(10);
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
        return round;

    }

    public void createPlayer()
    {
        GameObject player = Instantiate(PlayerPrefab) as GameObject;
        player.transform.SetParent(transform);
        Players.Add(player);
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
