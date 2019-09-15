﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectCard : CardDetail
{
    
    public string type;
    public bool PickAxe;
    public bool Lamb;
    public bool Cart;
    public EffectCard(string type,bool PickAxe,bool Lamb,bool Cart,Image frontCardArtWork, Image backCardArtWork) : base (frontCardArtWork,backCardArtWork)
    {
        this.type = type;
        this.PickAxe = PickAxe;
        this.Lamb = Lamb;
        this.Cart = Cart;
    }

    public void Apply(PlayerController Target)
    {
        if (!PickAxe)
            Target.PickAxe = false;
        if (!Lamb)
            Target.Lamb = false;
        if (!Cart)
            Target.Cart = false;
        Debug.Log("Apply type on " + Target.name);
    }


}
