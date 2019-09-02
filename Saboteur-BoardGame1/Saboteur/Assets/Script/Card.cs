//add this to card prefab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardDetail card;
    public Vector3 oldScale;
    public int rotation;
    bool cardBack = true;


    public void InitThisCard(int id)
    {
        
        card = CardDatabase.Instance.GetCard(id);
        if(card != null)
        {
            rotation = 0;
        }
        else
        {
            Debug.Log("could not load card from database");
        }
    }

    public void OnMouseOver()
    {
        this.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
    }

    public void OnMouseExit()
    {
        this.transform.localScale = oldScale;
    }

    public void rotate()
    {
        rotation = (rotation == 1) ? 0 : 1;
    }

    public void CheckValid()
    {
        card.checkValid();
    }

    

    

    


}
