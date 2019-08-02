using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathCard : CardDetail
{
    public int right, left, up, down, middle;
    public PathCard(int right, int up, int left, int down, int middle, Image frontCardArtWork, Image backCardArtWork) : base(frontCardArtWork, backCardArtWork)
    {
        this.right = right;
        this.up = up;
        this.left = left;
        this.down = down;
        this.middle = middle;
    }

    public bool ValidMove(Card[,] board, int x1, int y1, int x2, int y2)
    {
        if (board[x2, y2] != null)
        {// cannot place card on top of other card 
            return false;
        }
        else
        {

        }
        return true;
    }
}
