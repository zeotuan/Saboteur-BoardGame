using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : MonoBehaviour
{
    public bool Up = false;
    public bool Down = false;
    public bool Left = false;
    public bool Right = false;
    public bool center = false;
    public bool used = false;
    public int x;
    public int y;

    public void rotate()

    {
        Swap(Up, Down);
        Swap(Left, Right);
        this.gameObject.transform.Find("Image").Rotate(Vector3.forward * -180);
     

    }

    public void Swap(bool a, bool b)
    {
        a = a ^ b;
        b = b ^ a;
        a = a ^ b;
    }

}
