using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Button : MonoBehaviour
{
    public string[] Players_name;
    public void PlayGame()
    {
        this.transform.parent.Find("StartGame_Panel").gameObject.SetActive(true);
    }
    public void Setting()
    {
        SceneManager.LoadScene("3.PlayMenu Scene");
    }
    public void Exit()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void Confirm()
    {
        Players_name = new string[this.transform.parent.Find("StartGame_Panel/Input_Field").childCount];
        for (int i = 0;i< Players_name.Length; i++)
        {
            Players_name[i] = this.transform.parent.Find("StartGame_Panel/Input_Field").GetChild(i).Find("Text").GetComponent<Text>().text;
        }
        for(int i = 0;i< Players_name.Length;i++)
        {
            if (Players_name[i] == "")
            {
                Players_name[i] = "Player " + (i+1).ToString();
            }
        }
        SceneManager.LoadScene("9.InGame Scene");
    }
}