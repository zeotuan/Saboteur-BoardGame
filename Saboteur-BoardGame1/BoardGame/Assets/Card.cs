using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Image frontCardArtWork;
    public Image backCardArtWork;
    public Text cardName;
    //public ScriptableCard SCard;

    public Card(Image frontCardArtWork, Image backCardArtWork)
    {
        this.backCardArtWork = backCardArtWork;
        this.frontCardArtWork = frontCardArtWork;
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

    public bool validMove()
    {
        return false;
    }


}
