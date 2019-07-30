using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();
    void Awake()
    {
        cardList.Add(new Card(1, 1, 1, 1, 1));
        cardList.Add(new Card(1, 1, 1, 1, 0));
        //add more card here 
    }

}
