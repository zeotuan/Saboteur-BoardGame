using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FixCard : EffectCard
{
    public FixCard(string type,bool Pickaxe, bool Lamb, bool Cart, Sprite frontCardArtWork, Sprite backCardArtWork) : base(type,Pickaxe, Lamb, Cart, frontCardArtWork, backCardArtWork)
    {
    }

    public void Apply(PlayerController Target)
    {
        if (PickAxe)
            Target.PickAxe = true;
        if (Lamb)
            Target.Lamb = true;
        if (Cart)
            Target.Cart = true;
        Debug.Log("Apply Fix on " + Target.name);
    }
}
