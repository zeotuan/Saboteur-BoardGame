using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameManager : Singleton<GameManager>
{
    public PlayerController currentPlayer;
    StateMachine stateMachine = new StateMachine();
    public PlayerController[] players;

    void Start()
    {
        
    }
    void Update()
    {
        stateMachine.Update();
    }

    void Awake()
    {
        base.Awake();
    }

    
}
