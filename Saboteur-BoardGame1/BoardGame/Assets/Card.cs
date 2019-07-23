using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardS : MonoBehaviour
{
    public int right,left,up,down,rotate;
    public Image frontcardArtWork;
    public Image backCardArtWork;
    public Text  cardName;

    // card placing rule 
    public bool ValidMove(Card[.] board, int x1, int y1, int  x2, int y2){
        if(board[x2,y2]!= null){// cannot place card on top of other card 
            return  false;
        }

        if()
    }
}
