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


    /*public void LoadCard(ScriptableCard c){

        if(c == null)
            return;

        SCard = c;
        cardName.text = c.cardName;
        right = c.right;
        left = c.left;
        up = c.up;
        down = c.down;
        rotate = c.rotate;
        frontcardArtWork.sprite = c.FrontArt;
        backCardArtWork.sprite = c.BackArt;
    }*/



}
