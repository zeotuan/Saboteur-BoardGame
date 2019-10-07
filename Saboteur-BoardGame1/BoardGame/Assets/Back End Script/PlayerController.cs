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
            card.active = true;
            card.transform.SetParent(cardHolder);

        }
    }

    public void EndTurn()
    {
        MyTurn = false;
        foreach (GameObject card in hand)
        {
            card.transform.SetParent(transform);
            card.active = false;
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
        
        Board board =  GameObject.Find("Map").GetComponent<Board>();
        foreach(GameObject card in hand){
            CardDetail c = card.GetComponent<Card>().card;
            if(c is PathCard){
                Property cardProp = card.GetComponent<Property>();
                /*
                if(cardProp.Left){// if this card can be put on the right of some other card 
                    foreach(Property prop in board.GetPossibleRightPosition()){
                        if(checkValid((PathCard)c,prop.x, prop.y)){
                            board.setGrid(prop.x, prop.y, cardProp);
                            Discard(card);
                            return;
                        }
                    }
                }
                if (cardProp.Right){
                    foreach(Property prop in board.GetPossibleLeftPosition()){
                        if(checkValid((PathCard)c,prop.x, prop.y)){
                            board.setGrid(prop.x, prop.y, cardProp);
                            Discard(card);
                            return;
                        }
                    }
                }
                if (cardProp.Up){
                    foreach(Property prop in board.GetPossibleDownPosition()){
                        if(checkValid((PathCard)c,prop.x, prop.y)){
                            board.setGrid(prop.x, prop.y, cardProp);
                            Discard(card);
                            return;
                        }
                    }
                }
                if (cardProp.Down){
                    foreach(Property prop in board.GetPossibleUpPosition()){
                        if(checkValid((PathCard)c,prop.x, prop.y)){
                            board.setGrid(prop.x, prop.y, cardProp);
                            Discard(card);
                            return;
                        }
                    }
                } 
                */ 
            }else{
                Discard(card);
                return;
            }
        }
    }
}
