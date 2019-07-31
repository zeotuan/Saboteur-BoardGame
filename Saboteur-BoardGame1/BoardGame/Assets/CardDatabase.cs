using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CardDatabase : MonoBehaviour
{
    public List<Card> cardList = new List<Card>();
    public Image[] cardSprites;
    public Image[] cardBack;
    public static CardDatabase instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            instance = this;
            Destroy(instance.gameObject);
        }
        cardList.Add(new PathCard(1, 1, 1, 1, 1,cardSprites[0], cardBack[0]));
        cardList.Add(new PathCard(1, 1, 1, 1, 0, cardSprites[1], cardBack[0]));
        //add more card here 
    }

}
