using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu_Button : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("3.PlayMenu Scene");
    }
    public void Setting()
    {
        SceneManager.LoadScene("3.PlayMenu Scene");
    }
    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}