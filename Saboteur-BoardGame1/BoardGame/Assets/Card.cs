using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int right,left,up,down,middle,rotate;
    public Image frontcardArtWork;
    public Image backCardArtWork;
    public Text cardName;
    //public ScriptableCard SCard;
    Vector3 oldScale = new Vector3(1f, 1f, 1f);
    
    public Card(int right, int up, int left, int down, int middle)
    {
        this.right = right;
        this.up = up;
        this.left = left;
        this.down = down;
        this.middle = middle;
    }
    private void Start(){
        //LoadCard(SCard);
    }

    // card placing rule 
    public bool ValidMove(Card[,] board, int x1, int y1, int  x2, int y2){
        if(board[x2,y2]!= null){// cannot place card on top of other card 
            return  false;
        }
        else
        {
                
        }
        return true;
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

    public void OnMouseOver()
    {
        this.transform.localScale += new Vector3 (0.2f, 0.2f, 0.2f);
    }

    public void OnMouseExit()
    {
        this.transform.localScale = oldScale;
    }
}
