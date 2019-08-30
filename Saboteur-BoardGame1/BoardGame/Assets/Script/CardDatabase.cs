using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardDatabase : Singleton<CardDatabase>
{
    List<CardDetail> cardList = new List<CardDetail>();
    public Image[] cardSprites;
    public Image[] cardBack;
   
    void Awake()
    {
        base.Awake();
        cardList.Add(new PathCard(0, 0, 1, 1, 0,cardSprites[0], cardBack[0]));
        cardList.Add(new PathCard(1, 0, 0, 1, 0, cardSprites[1], cardBack[0]));
        cardList.Add(new PathCard(0, 1, 0, 1, 0, cardSprites[1], cardBack[0]));
        cardList.Add(new PathCard(0, 0, 1, 0, 1, cardSprites[1], cardBack[0]));
        cardList.Add(new PathCard(0, 1, 0, 0, 1, cardSprites[1], cardBack[0]));
        cardList.Add(new PathCard(0, 1, 1, 1, 0, cardSprites[1], cardBack[0]));
        cardList.Add(new PathCard(1, 1, 1, 1, 0, cardSprites[1], cardBack[0]));
        cardList.Add(new PathCard(1, 0, 1, 0, 0, cardSprites[1], cardBack[0]));
        cardList.Add(new PathCard(1, 1, 1, 0, 0, cardSprites[1], cardBack[0]));
        cardList.Add(new PathCard(1, 1, 1, 1, 0, cardSprites[1], cardBack[0]));
        cardList.Add(new PathCard(1, 0, 1, 0, 0, cardSprites[1], cardBack[0]));
        cardList.Add(new PathCard(1, 0, 1, 1, 1, cardSprites[1], cardBack[0]));
        cardList.Add(new PathCard(0, 0, 1, 1, 1, cardSprites[1], cardBack[0]));
        cardList.Add(new PathCard(1, 0, 0, 1, 1, cardSprites[1], cardBack[0]));
        cardList.Add(new PathCard(0, 1, 0, 1, 1, cardSprites[1], cardBack[0]));
        cardList.Add(new PathCard(1, 1, 0, 1, 1, cardSprites[1], cardBack[0]));
        cardList.Add(new PathCard(1, 1, 1, 1, 1, cardSprites[1], cardBack[0]));
        cardList.Add(new EffectCard("Fix Lamb", cardSprites[1], cardBack[0]));
        cardList.Add(new EffectCard("Break Lamb", cardSprites[1], cardBack[0]));
        cardList.Add(new EffectCard("Fix Cart", cardSprites[1], cardBack[0]));
        cardList.Add(new EffectCard("Break Cart", cardSprites[1], cardBack[0]));
        cardList.Add(new EffectCard("Fix PickAxe", cardSprites[1], cardBack[0]));
        cardList.Add(new EffectCard("Break PickAxe", cardSprites[1], cardBack[0]));
        cardList.Add(new EffectCard("Break Path", cardSprites[1], cardBack[0]));
        cardList.Add(new EffectCard("Fix Lamb and PickAxe", cardSprites[1], cardBack[0]));
        cardList.Add(new EffectCard("Fix Cart and PickAxe", cardSprites[1], cardBack[0]));
        cardList.Add(new EffectCard("Fix Lamb and Cart", cardSprites[1], cardBack[0]));
        cardList.Add(new EffectCard("View Destination", cardSprites[1], cardBack[0]));

        //add more card here 
    }

    public CardDetail GetCard(int id)
    {
        CardDetail result = null;
        result = cardList[id];
        return result;
    }

}
