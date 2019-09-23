using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash_Panel : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("2.Menu Scene");
    }
}
