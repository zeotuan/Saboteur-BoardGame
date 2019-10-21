using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp_menu : MonoBehaviour
{
    GameObject canvas;
    [SerializeField]
    bool gamePause = false; 
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePause = !gamePause;
            if (gamePause)
            {
                this.transform.Find("PopUp_menu").gameObject.SetActive(true);
                this.transform.Find("Pause_Panel").gameObject.SetActive(true);
                
                Time.timeScale = 0;
            }
            else
            {
                this.transform.Find("PopUp_menu").gameObject.SetActive(false);
                this.transform.Find("Pause_Panel").gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            
        }

    }
    public void resume()
    {
        this.transform.Find("PopUp_menu").gameObject.SetActive(false);
        this.transform.Find("Pause_Panel").gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
