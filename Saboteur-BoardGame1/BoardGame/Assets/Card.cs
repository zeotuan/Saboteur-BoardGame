using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int right,left,up,down,rotate;
    public Image frontcardArtWork;
    public Image backCardArtWork;
    public Text cardName;
    public ScriptableCard SCard;


    private void Start(){
        LoadCard(SCard);
    }

    // card placing rule 
    public bool ValidMove(Card[,] board, int x1, int y1, int  x2, int y2){
        if(board[x2,y2]!= null){// cannot place card on top of other card 
            return  false;
        }
        return true;
    }

    public void LoadCard(ScriptableCard c){

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
    }
}
