using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Property : MonoBehaviour
{
    public bool Up = false;
    public bool Down = false;
    public bool Left = false;
    public bool Right = false;
    public bool center = false;
    public bool used = false;
    public bool visited = false;
    public bool rotated = false;
    public int x;
    public int y;
    public Sprite frontCardArtWork;
    public Sprite backCardArtWork;

    public void rotate()

    {
        Swap(ref Up,ref Down);
        Swap(ref Left,ref  Right);
        //this.gameObject.transform.Rotate(Vector3.forward * -180);
        this.gameObject.transform.Find("Image").transform.Rotate(Vector3.forward * -180);
        rotated = !rotated;
    }

    public void Swap(ref bool a,ref bool b)
    {
        bool c;
        c = a;
        a = b;
        b = c;
    }

    public void showCardFront(){
           this.gameObject.transform.Find("Image").GetComponent<Image>().sprite = frontCardArtWork;
    }

    public void showCardBack(){
           this.gameObject.transform.Find("Image").GetComponent<Image>().sprite = backCardArtWork;
    }

}
