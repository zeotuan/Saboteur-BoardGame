using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyToLogin : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("3.Login Scene");
    }
}
