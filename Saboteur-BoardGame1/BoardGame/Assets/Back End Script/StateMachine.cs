using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    IState currentState;
    IState prevState;
    // Start is called before the first frame update
   
    // Update is called once per frame
    public void Update()
    {
        if(this.currentState != null)
            this.currentState.Execute();
    }

    public void ChangeState(IState newState)
    {
        if(this.currentState != null)
        {
           this.currentState.Exit();  
        }
        
        this.prevState = this.currentState;
        this.currentState = newState;
        this.currentState.Enter();

    }

    public void switchToPrevState()
    {
        this.currentState.Exit();
        this.currentState = this.prevState;
        this.currentState.Enter();
    }
}
