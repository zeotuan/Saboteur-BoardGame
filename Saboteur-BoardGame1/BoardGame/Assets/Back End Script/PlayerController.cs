//add this to player prefab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform cardHolder;
    public string playerName;
    public List<GameObject> hand;//list of card 
    //StateMachine StateMachine = new StateMachine();
    public bool PickAxe;
    public bool Lamb;
    public bool Cart;
    private bool MyTurn;
    private bool FinishTurn;
    private GameObject deck;
    private int Point;
    void Start()
    {
        
        //StateMachine.ChangeState()
    }
    
    public void Update()
    {   


        //StateMachine.Update();
        if (MyTurn )
        {
            if (FinishTurn)
            {
            }
        }
    }

    public void StartTurn()
    {
        MyTurn = true;
    }

    public void EndTurn()
    {
        MyTurn = false;
    }

    public void Discard(GameObject card)
    {
        hand.Remove(card);
        FinishTurn = true;
    }

    public void RenderCard()
    {
        if (MyTurn)
        {
            foreach(GameObject card in hand)
            {
                card.transform.SetParent(cardHolder);

            }
        }
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


}
