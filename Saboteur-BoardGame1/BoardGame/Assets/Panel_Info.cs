using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Info : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.Find("Player's name").GetComponent<Text>().text = this.transform.GetChild(10).GetComponent<PlayerController>().playerName;
        this.transform.Find("Text").GetComponent<Text>().text = this.transform.GetChild(10).GetComponent<PlayerController>().getPoint().ToString();
    }
}
