using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_Setting : MonoBehaviour
{
    // Start is called before the first frame update
    public void Resolution_800_600()
    {
        Screen.SetResolution(800, 600, true);
        /*
        if ()
        {
            Screen.SetResolution(800, 600, true);
        }
        else
        {
            Screen.SetResolution(800, 600, false);
        }
        */
        
    }
    public void Resolution_1024_768()
    {
        Screen.SetResolution(1024, 768, true);
    }
    public void Resolution_1280_800()
    {
        Screen.SetResolution(1280, 800, true);
    }
    public void Resolution_1366_768()
    {
        Screen.SetResolution(1366, 768, true);
    }
    public void Resolution_1440_900()
    {
        Screen.SetResolution(1440, 900, true);
    }
    public void Resolution_1680_1050()
    {
        Screen.SetResolution(1680, 1050, true);
    }
    public void Resolution_1920_1080()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    public void Resolution_1920_1200()
    {
        Screen.SetResolution(1920, 1200, true);
    }

    public void Full_Screen()
    {
        if (Screen.fullScreen == true)
        {
            Screen.fullScreen = false;
        }
        else
        {
            Screen.fullScreen = true;
        }
        
    }
}
