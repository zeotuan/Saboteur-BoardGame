using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class Draggable : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Transform parentToReturnTo = null;
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (this.transform.parent != this.transform.parent.Find("Map"))
        {
            this.transform.SetParent(this.transform.parent.Find("Map"));
        }
        else
        {
            this.transform.SetParent(parentToReturnTo);
        }

        //Get Path object from the Board script's board martix.
        GameObject[,] board = this.transform.parent.GetComponent<Board>().board;
        //initiate the variables
        float distance = Vector3.Distance(this.transform.position, board[0, 0].transform.position);
        int cloest_j = 0;
        int cloest_i = 0;
        //Find the closest path and it is not used yet.
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (Vector3.Distance(this.transform.position, board[j, i].transform.position) < distance)
                {
                    if (board[j, i].transform.GetComponent<Property>().used == false)
                    {
                        distance = Vector3.Distance(this.transform.position, board[j, i].transform.position);
                        cloest_j = j;
                        cloest_i = i;
                    }

                }
            }
        }
        //transform card's data to path
        board[cloest_j, cloest_i].transform.GetComponent<Property>().center = this.transform.GetComponent<Property>().center;
        board[cloest_j, cloest_i].transform.GetComponent<Property>().Down = this.transform.GetComponent<Property>().Down;
        board[cloest_j, cloest_i].transform.GetComponent<Property>().Up = this.transform.GetComponent<Property>().Up;
        board[cloest_j, cloest_i].transform.GetComponent<Property>().Left = this.transform.GetComponent<Property>().Left;
        board[cloest_j, cloest_i].transform.GetComponent<Property>().Right = this.transform.GetComponent<Property>().Right;
        board[cloest_j, cloest_i].transform.GetComponent<Property>().used = true;
        //transform the card's image to the path
        board[cloest_j, cloest_i].gameObject.GetComponent<Image>().sprite = this.gameObject.GetComponent<Image>().sprite;
        //Destroy the card object.
        Destroy(this.gameObject);
    }
}
