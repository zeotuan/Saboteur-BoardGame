using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class Draggable : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Transform parentToReturnTo = null;
    Board boardDetail;
    GameObject[,] board;
    public void Awake()
    {//Get Path object from the Board script's board martix.
        boardDetail = GameObject.Find("Map").GetComponent<Board>();
        board = boardDetail.board;
    }

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
        if (!this.GetComponent<Card>().Interactalbe)//effect card
        {
            this.transform.SetParent(parentToReturnTo);
            return;
        }
 
        //find closest path
        float distance = Vector3.Distance(this.transform.position, board[0, 0].transform.position);
        int cloest_j = 0;
        int cloest_i = 0;
        
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

        Property c = this.GetComponent<Property>();
        if (boardDetail.checkValid(c,cloest_j, cloest_i))
        {
            boardDetail.setGrid(cloest_j, cloest_i, this.transform.Find("Image").GetComponent<Image>().sprite, this.transform.GetComponent<Property>());
            GameManager.Instance.currRound.currPlayer.Discard(this.gameObject);
        }
        else
        {
            if(boardDetail.CheckDes(c,cloest_j,cloest_i)){
                boardDetail.setGrid(cloest_j, cloest_i, this.transform.Find("Image").GetComponent<Image>().sprite, this.transform.GetComponent<Property>());    
                GameManager.Instance.currRound.currPlayer.Discard(this.gameObject);    
            }
            //Debug.Log(this.transform.parent.name);
            this.transform.SetParent(parentToReturnTo);
        }
    }

    
    //need to  be change to accept card property instead and need to move to boaard script 
    
}
