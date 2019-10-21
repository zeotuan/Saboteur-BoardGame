using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Round_start_control : MonoBehaviour
{
    // Start is called before the first frame update
    public void setPoint(int Point)
    {
        this.transform.Find("Score number").GetComponent<Text>().text = Point.ToString();
    }


    public void setRole(string Role)
    {
        this.transform.Find("Role").GetComponent<Text>().text = Role;
    }
}
