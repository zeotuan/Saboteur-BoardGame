using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy_PathCard : CardDetail
{
    public Destroy_PathCard(Sprite frontCardArtWork, Sprite backCardArtWork) : base (frontCardArtWork, backCardArtWork)
    {
    }

    public void Apply(Property prop)
    {
        prop.Up = false;
        prop.Down = false;
        prop.Right = false;
        prop.Left = false;
        prop.center = false;
        prop.used = false;
        prop.rotated = false;
        prop.visited = false;
        prop.gameObject.transform.Find("Image").GetComponent<Image>().sprite = null;
        var tempColor = prop.gameObject.transform.Find("Image").GetComponent<Image>().color;
        tempColor = Color.black;
        tempColor.a = 0.4f;
        
        prop.gameObject.transform.Find("Image").GetComponent<Image>().color = tempColor;
    }

}
