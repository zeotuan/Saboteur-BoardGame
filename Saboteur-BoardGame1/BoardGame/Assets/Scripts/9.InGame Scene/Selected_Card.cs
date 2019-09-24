using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected_Card : MonoBehaviour
{
    public int card_number;
    GameObject card;

    public void setSelectedCard(GameObject c)
    {
        card = c;
    }

    public void Discard()
    {
        GameManager.Instance.currentRound.GetComponent<Round>().currentPlayer.GetComponent<PlayerController>().Discard(card);
        Destroy(card);
    }
}
