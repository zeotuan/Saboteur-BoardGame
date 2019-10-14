using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Time_Record : MonoBehaviour
{
    public float time;
    public void FixedUpdate()
    {
        this.gameObject.GetComponent<Text>().text = (int)time + " seconds left";
    }
}
