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
        for (int i = 0; i < 10; ++i)
        {
            SpawnMultipleCard(i, 1);
            if (i < 7)
            {
                SpawnMultipleCard(i + 10, 5);
            }
        }
        
        SpawnMultipleCard(17, 2);
        SpawnMultipleCard(18, 3);
        SpawnMultipleCard(19, 2);
        SpawnMultipleCard(20, 3);
        SpawnMultipleCard(21, 2);
        SpawnMultipleCard(22, 3);
        SpawnMultipleCard(23, 3);
        SpawnMultipleCard(24, 1);
        SpawnMultipleCard(25, 1);
        SpawnMultipleCard(26, 1);
        SpawnMultipleCard(27, 3);

    }

    void SpawnCard(int id)
    {
        Card cardObj = Instantiate(CardPrefab) as Card; 
        cardObj.transform.SetParent(transform);
        cardObj.InitThisCard(id);
        cardObj.transform.SetParent(this.transform.parent);
    }

    void SpawnMultipleCard(int id, int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            SpawnCard(id);
        }
    }
}
