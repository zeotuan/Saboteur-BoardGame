using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectCard : CardDetail
{
    public string type;
    public EffectCard(string type,Image frontCardArtWork, Image backCardArtWork) : base (frontCardArtWork,backCardArtWork)
    {
        this.type = type;
    }

    public void Apply(PlayerController Target)
    {
        Debug.Log("Apply type on " + Target.name);
    }


}
