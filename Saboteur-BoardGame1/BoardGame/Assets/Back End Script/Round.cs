using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
    bool RoundStarted;
    public GameObject deck;
    public GameObject deckPrefab;
    public int Turn { get; set; }
    public GameObject currentPlayer { get { return GameManager.Instance.Players[Turn]; } }
    bool ThisRoundTurn = false;
    bool roundEnd = false;
    private void Awake()
    {
        deck = Instantiate(deckPrefab) as GameObject;
        
    }
    void Start()
    {
        if (!RoundStarted)
        {
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
    }

    
    public void SwitchTurn()
    {
        RoundStarted = true;
        deck.GetComponent<Deck>().Deal(currentPlayer.GetComponent<PlayerController>(), RoundStarted);
        currentPlayer.GetComponent<PlayerController>().EndTurn();
        if (checkWinCondition())
        {
            roundEnd = true;
            EndRound();
            return;
        }
        Turn = Mathf.Abs(Turn - 1);
        currentPlayer.GetComponent<PlayerController>().StartTurn();
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
