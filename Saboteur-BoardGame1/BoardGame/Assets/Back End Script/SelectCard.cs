using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCard : IState
{
    public PlayerController owner;
    public SelectCard(PlayerController owner)
    {
        this.owner = owner;
    }
    public void Enter()
    {
        Debug.Log(owner.name + "'s Turn");
    }

    public void Execute()
    {

    }

    public void Exit()
    {
        Debug.Log(owner.name + "Finish His turn");
    }
}
