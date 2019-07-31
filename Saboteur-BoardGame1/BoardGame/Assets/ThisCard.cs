using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisCard : MonoBehaviour
{
    public Card card;
    public Vector3 oldScale;
    public int rotation;

    public void InitThisCard(int id)
    {
        if(CardDatabase.instance.cardList != null)
        {
            card = CardDatabase.instance.cardList[id];
            rotation = 0;
        }
        else
        {
            Debug.Log("could not load card database");
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

    


}
