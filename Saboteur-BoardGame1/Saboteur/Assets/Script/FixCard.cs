using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FixCard : EffectCard
{
    public FixCard(string type, Image frontCardArtWork, Image backCardArtWork) : base(type,frontCardArtWork, backCardArtWork)
    {
    }

    public void Apply(PlayerController Target)
    {
        Debug.Log("Apply type on " + Target.name);
    }
}
