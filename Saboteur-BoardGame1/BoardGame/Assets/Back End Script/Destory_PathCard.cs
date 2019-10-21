using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destory_PathCard : CardDetail
{
    public Destory_PathCard() : base(frontCardArtWork, backCardArtWork)
    {

    }

    public void Apply(Property prop)
    {
        prop.Up = false;
        prop.Down = false;
        prop.Right = false;
        prop.Left = false;
        prop.Center = false;
        prop.used = false;
        prop.rotated = false;
        prop.visited = false;
        prop.gameObject.transform.Find("Image").GetComponent<Image>().sprite = null;
        var tempColor = prop.gameObject.transform.Find("Image").GetComponent<Image>().color;
        tempColor.a = 100f;
        tempColor = Color.black;
        prop.gameObject.transform.Find("Image").GetComponent<Image>().color = tempColor;
    }

}
