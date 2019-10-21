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

        if (this.transform.Find("Role_assump").gameObject.activeInHierarchy)
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
        GameManager.Instance.currRound.GetCurPlayer().SetAssumption(this.gameObject.transform.Find("PlayerController(Clone)").GetComponent<PlayerController>().getTurnNum(),"dwarf");
        SetAssumptionPic("dwarf");
        Onclicks();
    }
    public void Sabotour_Assumtion()
    {
        GameManager.Instance.currRound.GetCurPlayer().SetAssumption(this.gameObject.transform.Find("PlayerController(Clone)").GetComponent<PlayerController>().getTurnNum(), "saboteur");
        SetAssumptionPic("saboteur");
        Onclicks();
    }

    public void SetAssumptionPic(string role)
    {
        if (role == "dwarf")
        {
            this.transform.Find("Panel").GetComponent<Image>().sprite = dwarf;
        }
        else
        {
            this.transform.Find("Panel").GetComponent<Image>().sprite = Sabotour;
        }
    }
}
