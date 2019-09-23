using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour,IDropHandler,IPointerEnterHandler,IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)//检测鼠标进入
    {
        //Debug.Log("OnPointerEnter to " + gameObject.name);
    }
    public void OnPointerExit(PointerEventData eventData)//检测鼠标离开
    {
        //Debug.Log("OnPointerExit to " + gameObject.name);
    }
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(eventData.pointerDrag.name + "was dropped on " + gameObject.name);
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        Property p = eventData.pointerDrag.GetComponent<Property>();
        if (d != null)
        {
        }
        else
        {
            //eventData.p.Down;
            //this.transform.Find('')
        }

    }
}
