﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectCard : Card
{
    public string type;
    public EffectCard(string type,Image frontCardArtWork, Image backCardArtWork) : base (frontCardArtWork,backCardArtWork)
    {
        this.type = type;
    }
}
