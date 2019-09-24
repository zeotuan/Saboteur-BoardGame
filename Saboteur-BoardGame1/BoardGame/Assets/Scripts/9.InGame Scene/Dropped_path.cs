using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropped_path : MonoBehaviour
{
    
   
    GameObject path;

    public void setSelectedPath(GameObject p)
    {
        path = p;
    }

    public void Rotate()
    {
        path.GetComponent<Property>().rotate();
        
    }
}
