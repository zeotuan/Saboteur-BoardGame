//add this to player prefab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform cardHolder;
    public string playerName;
    [SerializeField]
    public List<GameObject> hand;//list of card 
    //StateMachine StateMachine = new StateMachine();
    public bool PickAxe;
    public bool Lamb;
    public bool Cart;
    [SerializeField]
    private bool MyTurn;
    [SerializeField]
    private bool FinishTurn;
    private int Point;
    private string role;
    private bool IsBot;
    void Start()
    {
        cardHolder = GameObject.Find("Cards").transform;
        //StateMachine.ChangeState()
    }
    
    public void Update()
    {   


        //StateMachine.Update();
        if (MyTurn)
        {
            if (IsBot)
            {
                BotPlay();
            }
        }
        else
        {
            //
        }
    }

    public void StartTurn()
    {
        MyTurn = true;
        foreach (GameObject card in hand)
        {
            card.transform.SetParent(cardHolder);

        }
    }

    public void EndTurn()
    {
        MyTurn = false;
        foreach (GameObject card in hand)
        {
            card.transform.SetParent(transform);
        }
    }

    public void Discard(GameObject card)
    {
        hand.Remove(card);
        FinishTurn = true;
    }

    public void PlayCard(GameObject card)
    {
        FinishTurn = true;
        hand.Remove(card);
    }

    public bool Played()
    {
        if (FinishTurn)
        {
            FinishTurn = false;
            return true;
        }
        return FinishTurn;
    }

    public void setRole(string role)
    {
        this.role = role;
    }

    public void BotPlay()
    {

    }


}
