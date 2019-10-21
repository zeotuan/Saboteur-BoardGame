using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected_Card : MonoBehaviour
{
    public int card_number;
   public void Discard()
    {
        GameManager.Instance.currentRound.GetComponent<Round>().GetCurPlayer().GetComponent<PlayerController>().Discard(this.gameObject);
        //Destroy(card);
    }
}
