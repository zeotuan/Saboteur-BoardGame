using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameManager : Singleton<GameManager>
{
    //public static GameManager Instance { get; private set; }
    public int Turn { get; set; }
    public List<PlayerController> Players { get; private set; }
    public List<Round> Rounds { get; private set; }
    public PlayerController currentPlayer { get { return Players[Turn]; } }
    StateMachine stateMachine = new StateMachine();
    private bool gameStarted;
    
    public Deck deck;
   
    
    void Awake()
    {
        base.Awake();
        Players = new List<PlayerController>();
        gameStarted = false;
    }
    void Start()
    {
        if (!gameStarted)
        {
            currentPlayer.StartTurn();
        }
    }
    void Update()
    {
        stateMachine.Update();
    }
    
    public void SwitchTurn()
    {
        gameStarted = true;
        deck.Deal(currentPlayer,gameStarted);
        currentPlayer.EndTurn();
        if (checkWinCondition())
        {
            return;
        }
        Turn = Mathf.Abs(Turn - 1);
        currentPlayer.StartTurn();
    }

    bool checkWinCondition()
    {
        return false;
    }
   

    
}
