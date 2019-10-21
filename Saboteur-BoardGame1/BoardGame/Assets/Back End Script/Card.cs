//add this to card prefab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public CardDetail card;
    public Vector3 oldScale;
    public int rotation;
    bool cardBack = true;
    bool Selected = false;
    public bool Interactalbe = false;// should actually be draggable
    public void InitThisCard(int id)
    {
        
        card = CardDatabase.Instance.GetCard(id);
        //this.GetComponent<Image>().sprite = card.frontCardArtWork;
        this.transform.Find("Image").GetComponent<Image>().sprite = card.frontCardArtWork;
        
        Interactalbe = false;
        if (card != null)
        {
            if (card is PathCard)
            {
                Interactalbe = true;
                this.GetComponent<Property>().Up = ((PathCard)card).up;
                this.GetComponent<Property>().Down = ((PathCard)card).down;
                this.GetComponent<Property>().Left = ((PathCard)card).left;
                this.GetComponent<Property>().Right = ((PathCard)card).right;
                this.GetComponent<Property>().center = ((PathCard)card).middle;
                this.GetComponent<Property>().frontCardArtWork = card.frontCardArtWork;
                this.GetComponent<Property>().backCardArtWork = card.backCardArtWork;
            }else if (card is Destroy_PathCard){
                Interactalbe = true;
            }
                
            rotation = 0;
        }
        else
        {
            Debug.Log("could not load card from database");
        }
        
    }

    private void start()
    {
        
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
        if(card is PathCard)
        {
            this.gameObject.GetComponent<Property>().rotate();
        }
    }

    public void CheckValid()
    {
        card.checkValid();
    }

    public void OnClick()
    {
        this.GetComponent<activate>().selected(this.transform);
    }

    public CardDetail GetCardDetail(){
        return card;
    }








}
