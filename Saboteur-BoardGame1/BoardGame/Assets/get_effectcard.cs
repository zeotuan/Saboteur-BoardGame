using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_effectcard : MonoBehaviour
{

    // Start is called before the first frame update
    public void ApplyEffect()
    {
        CardDetail c = activate.currentlySelected.gameObject.GetComponent<Card>().card;
        if(c is EffectCard)
        {
            ((EffectCard)c).Apply(this.transform.GetChild(10).GetComponent<PlayerController>());
        }
        else if(c is FixCard)
        {
            ((FixCard)c).Apply(this.transform.GetChild(10).GetComponent<PlayerController>());
        }
        //GameManager.Instance.currentRound.GetComponent<Round>().currentPlayer.GetComponent<PlayerController>().Discard(this.gameObject);

        //this.transform.root.Find("Panel/Cards")
        GameManager.Instance.currRound.GetCurPlayer().Discard(activate.currentlySelected.gameObject);
    }

}
