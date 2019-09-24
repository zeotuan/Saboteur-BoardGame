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
    [SerializeField]
    float TimeLeft = 20;
    void Start()
    {
        
        if (!RoundStarted)
        {
            Turn = 0;
            foreach(GameObject player in GameManager.Instance.Players)
            {

                GameManager.Instance.deck.GetComponent<Deck>().Deal(player.GetComponent<PlayerController>(), RoundStarted);
                
            }
            currentPlayer.GetComponent<PlayerController>().StartTurn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime; 
        if(TimeLeft <= 0)
        {
            if(currentPlayer.GetComponent<PlayerController>().hand.Count > 4)
            {
                currentPlayer.GetComponent<PlayerController>().Discard(currentPlayer.GetComponent<PlayerController>().hand[4]);
            }
        }
        if (currentPlayer.GetComponent<PlayerController>().Played())
        {
            SwitchTurn();
        }   

    }

    public void StartRound()
    {
        ThisRoundTurn = true;
        Turn = 0;
    }

    
    public void SwitchTurn()
    {
        TimeLeft = 20;
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
        if (Turn == GameManager.Instance.Players.Count)
        {
            Turn = 0;    
        }
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
