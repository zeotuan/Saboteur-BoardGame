using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_info_control : MonoBehaviour
{
    public void Row_number(int Row_number)
    {
        this.transform.Find("Number").GetComponent<Text>().text = Row_number.ToString();
    }
    public void Player_name(string name)
    {
        this.transform.Find("Player's name Background/Player's name").GetComponent<Text>().text = name;
    }
    public void Total_Gold(int Gold_number)
    {
        this.transform.Find("Round/Text").GetComponent<Text>().text = Gold_number.ToString();
    }
}
