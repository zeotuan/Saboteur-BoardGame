using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_Destination : CardDetail
{
    public Show_Destination(Sprite frontCardArtWork, Sprite backCardArtWork) : base(frontCardArtWork, backCardArtWork)
    {

    }

    public void Apply(Property prop)
    {
        
        prop.gameObject.GetComponent<TempShowDes>().StartShowDes();
    }
}
