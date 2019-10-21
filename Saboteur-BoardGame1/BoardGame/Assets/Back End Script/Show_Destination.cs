using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_Destination : MonoBehaviour
{
    public Show_Destination(Sprite frontCardArtWork, Sprite backCardArtWork) : base(frontCardArtWork, backCardArtWork)
    {

    }

    public void Apply(Property prop)
    {
        prop.showDesfixedTime();
    }
}
