using UnityEngine.SceneManagement;
using UnityEngine;

public class Splash_key : MonoBehaviour
{
    // Update is called once per frame
    
    void FixedUpdate()
    {
        if(Input.anyKey)
        {
          SceneManager.LoadScene("2.Menu Scene");
        }
    }
    
}
