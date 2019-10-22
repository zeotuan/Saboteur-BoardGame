using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Round_slider : MonoBehaviour
{
    int number;
    public int max_round;
    public void Start()
    {
        number = 1;
        max_round = 1;
    }
    public void getnumber()
    {
        number = (int)this.GetComponent<Slider>().value;
        setnumber();
    }
    
    void setnumber()
    {
        this.transform.parent.GetComponent<Text>().text = "Round:" + number;
        max_round = number;
    }

    public void Confirm()
    {
        GameManager.Instance.setMaxRound(max_round);
    }
}
