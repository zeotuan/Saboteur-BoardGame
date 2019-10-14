using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathCard : CardDetail
{
    public bool right, left, up, down, middle;
    public PathCard(bool left, bool up, bool right, bool down, bool middle, Sprite frontCardArtWork, Sprite backCardArtWork) : base(frontCardArtWork, backCardArtWork)
    {
        this.right = right;
        this.up = up;
        this.left = left;
        this.down = down;
        this.middle = middle;
    }
}
