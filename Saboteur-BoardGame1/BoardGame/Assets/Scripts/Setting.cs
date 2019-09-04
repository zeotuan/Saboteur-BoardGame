using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public static bool menu_stat = false;
    public GameObject Pop_Up;
    // Update is called once per frame
    public void Pop_menu()
    {
        
        if (menu_stat == false)
        {
            Pop_Up.SetActive(true);
            menu_stat = true;
        }
        else
        {
            menu_stat = false;
            Pop_Up.SetActive(false);
        }
    }
}
