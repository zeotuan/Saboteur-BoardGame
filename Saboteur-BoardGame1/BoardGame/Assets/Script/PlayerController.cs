//add this to player prefab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string playerName;
    public List<Card> hand = new List<Card>();
    StateMachine StateMachine = new StateMachine();
    public bool PickAxe;
    public bool Lamb;
    public bool Cart;

    void Start()
    {
        //StateMachine.ChangeState()
    }
    
    void Update()
    {
        StateMachine.Update();
    }
}
