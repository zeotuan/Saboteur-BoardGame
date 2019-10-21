using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cover_Script : MonoBehaviour
{
    public void Buttons()
    {
        this.gameObject.SetActive(false);
        GameManager.Instance.currRound.setTimeLeft(10);
    }

    public void setText(string playerName)
    {
        this.transform.Find("Text").GetComponent<Text>().text = playerName+"'s turn"; 
    }
}
