//add this to player prefab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
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
        if (MyTurn && FinishTurn)
        {
            FinishTurn = false;
            GameManager.Instance.currentRound.SwitchTurn();
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

    public void Discard(Card c)
    {
        hand.Remove(c);
        FinishTurn = true;
    }


}
