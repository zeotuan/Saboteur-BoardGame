using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempShowDes : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartShowDes()
    {
        StartCoroutine(ShowDes());
    }
    IEnumerator ShowDes()
    {
        this.gameObject.transform.Find("tempImage").gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        this.gameObject.transform.Find("tempImage").gameObject.SetActive(false);
    }
}
