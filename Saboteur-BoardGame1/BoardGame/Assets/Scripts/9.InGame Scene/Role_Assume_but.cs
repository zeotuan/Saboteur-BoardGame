using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Role_Assume_but : MonoBehaviour
{
    public Sprite dwarf;
    public Sprite Sabotour;
    // Start is called before the first frame update
    public void Onclicks()  
    {
        if (this.transform.Find("Role_assump").gameObject.activeInHierarchy==true)
        {
            this.transform.Find("Role_assump").gameObject.SetActive(false);
        }
        else
        {
            this.transform.Find("Role_assump").gameObject.SetActive(true);
        }
    }
    public void Dwarf_Assumtion()
    {
        this.transform.Find("Panel").GetComponent<Image>().sprite = dwarf;
        Onclicks();
    }
    public void Sabotour_Assumtion()
    {
        this.transform.Find("Panel").GetComponent<Image>().sprite = Sabotour;
        Onclicks();
    }
}
