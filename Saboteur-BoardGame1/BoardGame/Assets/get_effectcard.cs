using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_effectcard : MonoBehaviour
{
    
    // Start is called before the first frame update
    void ApplyEffect()
    {
        CardDetail c = activate.currentlySelected.gameObject.GetComponent<Card>().card;
        if(c is EffectCard)
        {
            ((EffectCard)c).Apply(this.transform.GetChild(10).GetComponent<PlayerController>());
        }
        else if(c is FixCard)
        {
            ((FixCard)c).Apply(GameManager.Instance.Players[Random.Range(0, 4)].GetComponent<PlayerController>());
        }
        //this.transform.root.Find("Panel/Cards")
    }

}
