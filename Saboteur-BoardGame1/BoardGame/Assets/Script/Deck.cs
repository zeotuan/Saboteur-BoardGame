//add this to deck gameObject
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    Card CardPrefab; 

    void Start()
    {
        GenerateDeck(10);
    }
    void GenerateDeck(int numberPlayer)
    {
        for(int i = 0; i < 10; i++)
        {
            SpawnCard(1);
        }
    }

    void SpawnCard(int id)
    {
        Card cardObj = Instantiate(CardPrefab) as Card;
        cardObj.transform.SetParent(transform);
        cardObj.InitThisCard(id);
    }
}
