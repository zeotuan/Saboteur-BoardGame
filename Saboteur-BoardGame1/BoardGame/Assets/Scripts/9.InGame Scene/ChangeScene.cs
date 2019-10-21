using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void ChangeScenes()
    {
        //this.GetComponent<Round>().TimeLeft = 0;
        SceneManager.LoadScene("2.Menu Scene");
        DestroyImmediate(GameManager.Instance.gameObject);
    }
    public void Quit_game()
    {
        Application.Quit();
    }
}
