using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role_button : MonoBehaviour
{
    public void buttons()
    {
        this.transform.parent.Find("Role").gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
