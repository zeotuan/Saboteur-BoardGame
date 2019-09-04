using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_sending : MonoBehaviour
{

    public GameObject BGM;
    // Start is called before the first frame update
    void Start()
    {
        
        GameObject.DontDestroyOnLoad(BGM);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
