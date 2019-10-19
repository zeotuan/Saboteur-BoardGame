using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDetail
{
    public Sprite frontCardArtWork;
    public Sprite backCardArtWork;
    public Text cardName;
    //public ScriptableCard SCard;

    public CardDetail(Sprite frontCardArtWork, Sprite backCardArtWork)
    {
        this.backCardArtWork = backCardArtWork;
        this.frontCardArtWork = frontCardArtWork;
    }

    public virtual bool checkValid()
    {
        return false;
    }





}
