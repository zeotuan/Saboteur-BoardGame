﻿//add this to deck gameObject
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public GameObject CardPrefab;
    public List<GameObject> deck;

    private void Awake()
    {
        GenerateDeck(10);
        
    }
    void Start()
    {
        shuffle();
        //xGameManager.Instance.shuffle(deck);
    }

    public void GenerateDeck(int numberPlayer)
    {
        
        //generated all needed card
        for (int i = 0; i < 6; ++i)
        {
            SpawnCard(i);
            
        }
        SpawnMultipleCard(6, 2);
        SpawnCard(7);
        SpawnCard(8);
        SpawnMultipleCard(9, 2);
        SpawnMultipleCard(10, 2);
        SpawnMultipleCard(11, 2);
        SpawnMultipleCard(12, 2);
        SpawnMultipleCard(13, 2);
        SpawnMultipleCard(14, 2);
        SpawnMultipleCard(15, 2);
        SpawnMultipleCard(16, 2);
        SpawnMultipleCard(17, 3);
        SpawnMultipleCard(18, 2);
        SpawnMultipleCard(19, 3);
        SpawnMultipleCard(20, 2);
        SpawnMultipleCard(21, 3);
        SpawnMultipleCard(22, 3);
        SpawnMultipleCard(23, 1);
        SpawnMultipleCard(24, 1);
        SpawnMultipleCard(25, 1);
        SpawnMultipleCard(26, 3);
        

    }

    void SpawnCard(int id)
    {

        GameObject cardObj = Instantiate(CardPrefab) as GameObject;
        cardObj.transform.SetParent(transform);
        Card cardScript = cardObj.GetComponent<Card>();
        cardScript.InitThisCard(id);
        cardObj.GetComponent<activate>().enabled = false;
        
        deck.Add(cardObj);
        
    }

    void SpawnMultipleCard(int id, int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            SpawnCard(id);  
        }
    }

    void shuffle()
    {
        for(int i =0; i < deck.Count; i++)
        {
            var container = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container;
        }
    }

    public void Deal( PlayerController target)
    {
        int UpperCardIndex = deck.Count - 1;
        if(deck.Count <= 0)
        {
            Debug.Log("out of card");
            return;
        }
        
        target.hand.Add(deck[UpperCardIndex]);
        deck[UpperCardIndex].transform.SetParent(target.transform);
        deck.RemoveAt(UpperCardIndex);
        
    }
}
