using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameManager : Singleton<GameManager>
{
    //public static GameManager Instance { get; private set; }
    public int RoundTurn { get; set; }
    public List<PlayerController> Players { get; private set; }
    public List<Round> Rounds { get; private set; }
    public Round currentRound { get { return Rounds[RoundTurn]; } }

    StateMachine stateMachine = new StateMachine();
    private bool gameStarted;
    
   
    
    void Awake()
    {
        base.Awake();
        Players = new List<PlayerController>();
        Rounds = new List<Round>();
        for(int i = 0; i < 6; i++)// innitate 7 player
        {
            PlayerController player = new PlayerController();
            Players.Add(player);
        }
        for(int i =0; i < 4; i++)// initiate 5 round 
        {
            Round round = new Round();
            Rounds.Add(round);
        }
        gameStarted = false;
    }
    void Start()
    {
        if (!gameStarted)
        {
            currentRound.StartRound();
        }
    }
    void Update()
    {
        stateMachine.Update();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //QuitGamePanel.gameObject.SetActive(true);
        }

            
    }

    public void SwitchRound()
    {
        gameStarted = true;
        currentRound.EndRound();
        RoundTurn = Mathf.Abs(RoundTurn - 1);
        currentRound.StartRound();
    }
    
    

    bool checkWinCondition()
    {
        return false;
    }
   

    
}
