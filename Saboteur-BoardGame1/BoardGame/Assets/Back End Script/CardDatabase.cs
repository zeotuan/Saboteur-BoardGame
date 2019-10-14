using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardDatabase : Singleton<CardDatabase>
{
    public List<CardDetail> cardList = new List<CardDetail>();
    public Sprite[] cardSprites;
    public Sprite[] cardBack;
   
    void Awake()
    {
        base.Awake();//list start from 1 to 27
        cardList.Add(new PathCard(false, false, true, true, false, cardSprites[0], cardBack[0]));
        cardList.Add(new PathCard(true, false, false, true, false, cardSprites[1], cardBack[0]));
        cardList.Add(new PathCard(false, true, false, true, false, cardSprites[2], cardBack[0]));
        cardList.Add(new PathCard(false, false, true, false, true, cardSprites[3], cardBack[0]));
        cardList.Add(new PathCard(false, true, false, false, true, cardSprites[4], cardBack[0]));
        cardList.Add(new PathCard(false, true, true, true, false, cardSprites[5], cardBack[0]));
        cardList.Add(new PathCard(true, true, true, true, false, cardSprites[6], cardBack[0]));
        cardList.Add(new PathCard(true, false, true, false, false, cardSprites[7], cardBack[0]));
        cardList.Add(new PathCard(true, true, true, false, false, cardSprites[8], cardBack[0]));
        cardList.Add(new PathCard(true, false, true, false, true, cardSprites[9], cardBack[0]));
        cardList.Add(new PathCard(true, false, true, true, true, cardSprites[10], cardBack[0]));
        cardList.Add(new PathCard(false, false, true, true, true, cardSprites[11], cardBack[0]));
        cardList.Add(new PathCard(true, false, false, true, true, cardSprites[12], cardBack[0]));
        cardList.Add(new PathCard(false, true, false, true, true, cardSprites[13], cardBack[0]));
        cardList.Add(new PathCard(true, true, false, true, true, cardSprites[14], cardBack[0]));
        cardList.Add(new PathCard(true, true, true, true, true, cardSprites[15], cardBack[0]));
        cardList.Add(new FixCard("Fix Lamb",false,true,false, cardSprites[16], cardBack[0]));
        cardList.Add(new EffectCard("Break Lamb",true,false,true, cardSprites[17], cardBack[0]));
        cardList.Add(new FixCard("Fix Cart",false,false,true, cardSprites[18], cardBack[0]));
        cardList.Add(new EffectCard("Break Cart",true,true,false, cardSprites[19], cardBack[0]));
        cardList.Add(new FixCard("Fix PickAxe",true,false,false, cardSprites[20], cardBack[0]));
        cardList.Add(new EffectCard("Break PickAxe",false,true,true, cardSprites[21], cardBack[0]));
        cardList.Add(new EffectCard("Break Path",false,false,false, cardSprites[22], cardBack[0]));
        cardList.Add(new FixCard("Fix Lamb and PickAxe",true,true,false, cardSprites[23], cardBack[0]));
        cardList.Add(new FixCard("Fix Cart and PickAxe",true,false,true, cardSprites[24], cardBack[0]));
        cardList.Add(new FixCard("Fix Lamb and Cart",false,true,true, cardSprites[25], cardBack[0]));
        cardList.Add(new EffectCard("View Destination",true,true,true, cardSprites[26], cardBack[0]));
        Debug.Log("there are :"+cardList.Count + "card type in database" );
        
        //add more card here 
    }

    private void Start()
    {
        
    }
    public CardDetail GetCard(int id)
    {
        
        CardDetail result = null;
        result = cardList[id];
        return result;
    }

}
