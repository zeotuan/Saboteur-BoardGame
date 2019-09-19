//add this to deck gameObject
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public Card CardPrefab;
    public List<Card> deck;
    public List<Card> containter;

    private void Awake()
    {
        GenerateDeck(10);
        
    }
    void Start()
    {
        shuffle();
    }
    void GenerateDeck(int numberPlayer)
    {
        //generated all needed card
        for (int i = 1; i < 11; ++i)
        {
            SpawnMultipleCard(i, 1);
            if (i < 8)
            {
                SpawnMultipleCard(i + 10, 4);
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
            containter[0] = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = containter[0];
        }
    }

    public void Deal( PlayerController target, bool gameStarted)
    {
        int UpperCardIndex = deck.Count - 1;
        if (gameStarted)
            deck[UpperCardIndex].GetComponent<Renderer>().enabled = false;
        else//
            deck[UpperCardIndex].transform.SetParent(target.transform);// Later on will not target transform of player but a placeHolder object for card(need to be changed) 

        target.hand.Add(deck[UpperCardIndex]);
        deck.RemoveAt(UpperCardIndex);
    }
}
