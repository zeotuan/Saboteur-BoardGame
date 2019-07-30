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
    public Transform parentToReturnTo = null;
    GameObject placeHolder = null;
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        

        placeHolder = new GameObject();
        placeHolder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeHolder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleHeight = 0;
        le.flexibleWidth = 0;
        placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;

        int newSiblingIndex = parentToReturnTo.childCount; 
        
        for(int i = 0; i < parentToReturnTo.childCount; i++)
        {
            if(this.transform.position.x < parentToReturnTo.GetChild(i).position.x)
            {
                newSiblingIndex = i;
                if(placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
                {
                    i--;
                }
                break;
            }
        }
        placeHolder.transform.SetSiblingIndex(newSiblingIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        bool validPos = false;
        if (validPos)
        {
            this.transform.position = StartDrag;
        }
        else
        {
            this.transform.SetParent(parentToReturnTo);
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
        Destroy(placeHolder);

        //EventSystem.current.RaycastAll(eventData, )
    }
}
