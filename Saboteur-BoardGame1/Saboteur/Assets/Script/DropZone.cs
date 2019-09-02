using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject board;
    Vector3 TruePos;
    public static float gridsize;
    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
    public void OnDrop(PointerEventData eventData)
    {
        DragS d = eventData.pointerDrag.GetComponent<DragS>();
        if(d!= null)
        {
            Card c = eventData.pointerDrag.GetComponent<Card>();
            TruePos.x = Mathf.Floor(eventData.pointerDrag.transform.position.x / gridsize) * gridsize;
            TruePos.y = Mathf.Floor(eventData.pointerDrag.transform.position.y / gridsize) * gridsize;
            TruePos.z = Mathf.Floor(eventData.pointerDrag.transform.position.z / gridsize) * gridsize;

            if (board.GetComponent<Board>().checkValid(c, (int)TruePos.x, (int)TruePos.y))//check if the move is valid 
            {
                d.parentToReturnTo = this.transform;
                if (c.card is PathCard)
                {
                    c.transform.position = TruePos;
                }
            }
        }
    }

}
