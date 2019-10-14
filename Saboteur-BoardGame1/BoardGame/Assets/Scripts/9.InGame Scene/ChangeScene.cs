using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void ChangeScenes()
    {
        SceneManager.LoadScene("2.Menu Scene");       
    }

    public void Update()
    {
        /*
        GameObject root = GameObject.Find("GameManager");
        Debug.Log(root.transform.Find("Player 1").name);
        */
    }
}
