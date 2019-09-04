using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby2ToLogin : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("3.Login Scene");
    }
}
