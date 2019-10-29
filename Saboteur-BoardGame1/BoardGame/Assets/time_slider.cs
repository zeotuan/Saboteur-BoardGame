using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time_slider : MonoBehaviour
{
    int time = 5;
    // Start is called before the first frame update

    public void ChangeValue()
    {
        time = (int)this.GetComponent<Slider>().value;
        this.transform.parent.Find("Turn time").GetComponent<Text>().text = "Turn time: " + time + "s";


    }

    public void Confirm()
    {
        GameManager.Instance.setTurnTime(time);
    }
}
