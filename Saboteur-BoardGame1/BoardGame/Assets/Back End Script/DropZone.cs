using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject board;
   // Vector3 TruePos;
    public float gridsize;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        DragS d = eventData.pointerDrag.GetComponent<DragS>();
        if(d!= null)
        {
            d.dropzone = this;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DragS d = eventData.pointerDrag.GetComponent<DragS>();
        if (d != null)
        {
            d.dropzone = null;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        DragS d = eventData.pointerDrag.GetComponent<DragS>();
        if(d!= null)
        {
            Card c = eventData.pointerDrag.GetComponent<Card>();
            /*TruePos.x = Mathf.Floor(eventData.pointerDrag.transform.position.x / gridsize) * gridsize;
            TruePos.y = Mathf.Floor(eventData.pointerDrag.transform.position.y / gridsize) * gridsize;
            TruePos.z = Mathf.Floor(eventData.pointerDrag.transform.position.z / gridsize) * gridsize;
           */
            d.parentToReturnTo = this.transform;
            eventData.pointerDrag.GetComponent<MoveMenu>().enabled = true;
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
