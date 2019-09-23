
using UnityEngine;

public class ActiveMainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    private bool flag = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!flag)
            {
                MainMenu.SetActive(true);
                flag = true;
            }
            else
            {
                MainMenu.SetActive(false);
                flag = false;
            }
        }
    }
}
