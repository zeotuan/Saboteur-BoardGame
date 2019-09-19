﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZoneS : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject board;
   // Vector3 TruePos;
    public float gridsize;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        /*DragS d = eventData.pointerDrag.GetComponent<DragS>();
        if(d!= null)
        {
            d.dropzone = this;//not really needed to be written like this ?
        }
        else
        {
            Debug.Log("card not exist");
        }*/
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        /*DragS d = eventData.pointerDrag.GetComponent<DragS>();
        if (d != null)
        {
            d.dropzone = null;
        }*/
    }
    public void OnDrop(PointerEventData eventData)
    {
        DragS d = eventData.pointerDrag.GetComponent<DragS>();
        if(d!= null)
        {
            Card c = eventData.pointerDrag.GetComponent<Card>();
            d.parentToReturnTo = this.transform;
            
            if (board.GetComponent<Board>().checkValid(c, (int)d.TruePos.x, (int)d.TruePos.y))//if move is valid then  
            {
                
                if (c.card is PathCard)// not actually needed anymore since Effect card can no longer be moved 
                {
                    //d.transform.position = d.TruePos;// could be c.transform.position
                    c.Interactalbe = false;
                }
            }
        }
    }

}
