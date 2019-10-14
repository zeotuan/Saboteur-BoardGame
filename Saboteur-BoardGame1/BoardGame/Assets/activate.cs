using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate : MonoBehaviour
{
    public static Transform currentlySelected;
    // Start is called before the first frame update
    public void Activate()
    {
            if (this.GetComponent<Card>().card is PathCard)
            {
                //this.gameObject.active()
                this.transform.Find("Path").gameObject.SetActive(true);
                
                this.transform.parent.parent.Find("Left/Player's panel/Effect").gameObject.SetActive(false);

            }
            else
            {
                this.transform.Find("Effect").gameObject.SetActive(true);
                this.transform.parent.parent.Find("Left/Player's panel/Effect").gameObject.SetActive(true);
            }
        
    }

    public void DeActivate()
    {
        if (this.GetComponent<Card>().card is PathCard)
        {
            this.transform.Find("Path").gameObject.SetActive(false);
        }
        else
        {
            this.transform.Find("Effect").gameObject.SetActive(false);
        }
    }
    public void Update()
    {
        if(currentlySelected == this.transform)
        {
            Activate();
        }
        else
        {
            DeActivate();
        }
    }

    public void selected(Transform t)
    {
        currentlySelected = t;
    }
}
