using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
    bool RoundStarted;
    public Deck deck;
    public int Turn { get; set; }
    public PlayerController currentPlayer { get { return GameManager.Instance.Players[Turn]; } }
    bool ThisRoundTurn = false;
    bool roundEnd = false;
    private void Awake()
    {
        deck = new Deck();

    }
    void Start()
    {
        if (!RoundStarted)
        {
            
            currentPlayer.StartTurn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRound()
    {
        ThisRoundTurn = true;
    }

    
    public void SwitchTurn()
    {
        RoundStarted = true;
        deck.Deal(currentPlayer, RoundStarted);
        currentPlayer.EndTurn();
        if (checkWinCondition())
        {
            roundEnd = true;
            EndRound();
            return;
        }
        Turn = Mathf.Abs(Turn - 1);
        currentPlayer.StartTurn();
    }

    bool checkWinCondition()
    {
        return false;
    }

    public void EndRound()
    {
        ThisRoundTurn = false;
    }
}
