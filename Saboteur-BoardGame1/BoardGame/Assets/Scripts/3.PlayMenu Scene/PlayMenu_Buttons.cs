using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayMenu_Buttons : MonoBehaviour
{
    public void LocalGame()
    {
        SceneManager.LoadScene("9.InGame Scene");
    }
    public void LanGame()
    {
        SceneManager.LoadScene("9.InGame Scene");
    }
    public void WanGame()
    {
        SceneManager.LoadScene("4.Begin Scene");
    }
    public void Back()
    {
        SceneManager.LoadScene("2.Menu Scene");
    }
}