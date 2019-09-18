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

    public bool checkValid(PathCard[,] board,int x, int y)
    {

            if (board[x, y] == null)//if the position is blank
            {
                PathCard left = board[x - 1, y];//left card to this card
                PathCard below = board[x, y - 1];//below card to this card
                PathCard right = board[x + 1, y];//right card to this card
                PathCard above = board[x, y + 1];// above card to this card

                bool valid = true;
                if (this.right != right.left)
                {
                    valid = false;
                }
                else if (this.left != left.right) 
                {
                    valid = false;
                }
                else if (this.up != above.down)
                {
                    valid = false;
                }
                else if (this.down != below.up)
                {
                    valid = false;
                }
                return valid;
            }

        return false;
        
    }

    public void Rotate()
    {
        Swap(up, down);
        Swap(left, right);
    }

    public void Swap(int a, int b)
    {
        a = a ^ b;
        b = b ^ a; 
        a = a ^ b;
    }

    
}
