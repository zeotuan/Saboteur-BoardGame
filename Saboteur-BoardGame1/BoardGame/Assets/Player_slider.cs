using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_slider : MonoBehaviour
{
    public GameObject play_input_prefab;
    public int PlayerNumber = 3;
    public void Start()
    {
        PlayerNumber = 3;
        GameObject.Instantiate(play_input_prefab).transform.SetParent(this.transform.parent.parent.Find("Input_Field"));
        GameObject.Instantiate(play_input_prefab).transform.SetParent(this.transform.parent.parent.Find("Input_Field"));
        GameObject.Instantiate(play_input_prefab).transform.SetParent(this.transform.parent.parent.Find("Input_Field"));
    }
    // Start is called before the first frame update
    public void GetPlayernumber()
    {
        PlayerNumber = (int)this.GetComponent<Slider>().value;
        //GameObject.Instantiate(play_input_prefab).transform.SetParent(this.transform.parent.parent.Find("Input_Field"));
        intial();
    }
    void intial()
    {
        this.transform.parent.GetComponent<Text>().text = "Player:" + PlayerNumber;
        
        
        if (this.transform.parent.parent.Find("Input_Field").childCount < PlayerNumber)
        {
            for (int i = this.transform.parent.parent.Find("Input_Field").childCount; i < PlayerNumber; i++)
            {
                GameObject.Instantiate(play_input_prefab).transform.SetParent(this.transform.parent.parent.Find("Input_Field"));
            }
        }
        else if(this.transform.parent.parent.Find("Input_Field").childCount > PlayerNumber)
        {
            int j = this.transform.parent.parent.Find("Input_Field").childCount;
            while (j > PlayerNumber)
            {
                Destroy(this.transform.parent.parent.Find("Input_Field").GetChild(j-1).gameObject);
                j--;
            }
        }
        for(int i = 0;i< this.transform.parent.parent.Find("Input_Field").childCount;i++)
        {
            this.transform.parent.parent.Find("Input_Field").GetChild(i).Find("Player's name").GetComponent<Text>().text = "Player " + (i + 1) + " 's name:";
        }
        
    }
}
