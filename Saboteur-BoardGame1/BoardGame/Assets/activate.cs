using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate : MonoBehaviour
{
    public static Transform currentlySelected;
    // Start is called before the first frame update
    public void Activate()
    {
        CardDetail c = this.GetComponent<Card>().card;
            if (c is PathCard)
            {
                //this.gameObject.active()
                this.transform.Find("Path").gameObject.SetActive(true);
                

            //this.transform.root.Find("Panel/Left/Player's panel/Select").gameObject.SetActive(false);
            }
            else if (c is EffectCard) 
            {
                this.transform.Find("Effect").gameObject.SetActive(true);

            ///this.transform.root.Find("Panel/Left").gameObject.SetActive(true);
            for(int i =0; i < this.transform.root.Find("Panel/Left").childCount; i++)
            {
                this.transform.root.Find("Panel/Left").GetChild(i).Find("Select").gameObject.SetActive(true);
            }
            
            }
        this.transform.Find("Discard").gameObject.SetActive(true);

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
        if(currentlySelected == null)
        {
            for (int i = 0; i < this.transform.root.Find("Panel/Left").childCount; i++)
            {
                this.transform.root.Find("Panel/Left").GetChild(i).Find("Select").gameObject.SetActive(false);
            }
        }
        else if (currentlySelected == this.transform && this.GetComponent<Card>().card is PathCard)
        {
            for (int i = 0; i < this.transform.root.Find("Panel/Left").childCount; i++)
            {
                this.transform.root.Find("Panel/Left").GetChild(i).Find("Select").gameObject.SetActive(false);
            }
        }
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
