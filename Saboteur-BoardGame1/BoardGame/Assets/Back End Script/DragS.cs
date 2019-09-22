    //add this script to card1 prefab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragS : MonoBehaviour, IDragHandler
{
    Vector2 StartDrag;
    Vector2 EndDrag;
    public Transform Hand;
    public Transform parentToReturnTo = null;
    GameObject placeHolder = null;
    public DropZoneS dropzone = null;
    public Vector3 TruePos;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Card c = eventData.pointerDrag.GetComponent<Card>();
        if (c == null || !c.Interactalbe)// if card is not interactable then do nothing
        {
            Debug.Log("not interactable");
            return;
        }
        Hand = this.transform.parent;
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        


        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        Vector3 ToPos = eventData.position;
        
        this.transform.position = ToPos;
        
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
       

        //EventSystem.current.RaycastAll(eventData, )
    }

    
}
