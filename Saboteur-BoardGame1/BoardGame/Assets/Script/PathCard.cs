using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathCard : CardDetail
{
    public int right, left, up, down, middle;
    int x, y;
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
                PathCard above = board[x - 1, y];
                PathCard left = board[x, y - 1];
                PathCard below = board[x + 1, y];
                PathCard right = board[x, y + 1];

                checkFit(above);
                checkFit(left);
                checkFit(below);
                checkFit(right);
            }

        return false;
        
    }

    private void checkFit(PathCard c)
    {
        if (x < c.x && )
        {

        }
        else if (x > c.x)
        {

        }
        else if (y < c.y)
        {

        }
        else if (y > c.y)
        {

        }
    }
}
