using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby2ToIngame : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("7.InGame Scene");
    }
}
