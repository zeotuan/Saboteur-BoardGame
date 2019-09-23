using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyToLogin : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("5.Login Scene");
    }
}
