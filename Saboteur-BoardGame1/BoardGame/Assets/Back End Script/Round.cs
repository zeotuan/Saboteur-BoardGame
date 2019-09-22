using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
    bool RoundStarted;
    public int Turn;
    public GameObject currentPlayer { get { return GameManager.Instance.Players[Turn]; } }
    bool ThisRoundTurn = false;
    bool roundEnd = false;
   
    void Start()
    {
        
        if (!RoundStarted)
        {
            Turn = 0;
            currentPlayer.GetComponent<PlayerController>().StartTurn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRound()
    {
        ThisRoundTurn = true;
        Turn = 0;
    }

    
    public void SwitchTurn()
    {
        RoundStarted = true;
        GameManager.Instance.deck.GetComponent<Deck>().Deal(currentPlayer.GetComponent<PlayerController>(), RoundStarted);
        currentPlayer.GetComponent<PlayerController>().EndTurn();
        if (checkWinCondition())
        {
            roundEnd = true;
            EndRound();
            return;
        }
        Turn++;
        if (Turn < GameManager.Instance.Players.Count)
        {
            currentPlayer.GetComponent<PlayerController>().StartTurn();
        }
        else
        {
            Turn = 0;
        }
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
