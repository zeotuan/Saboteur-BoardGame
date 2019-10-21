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
        Card c = this.GetComponent<Card>();
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (!c.Interactalbe)//effect card
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
                    //if (board[j, i].transform.GetComponent<Property>().used == false)
                    //{
                        distance = Vector3.Distance(this.transform.position, board[j, i].transform.position);
                        cloest_j = j;
                        cloest_i = i;
                    //}

                }
            }
        }

        Property p = this.GetComponent<Property>();
        Property closest = board[cloest_j, cloest_i].GetComponent<Property>();
        CardDetail cDetail = c.card;
        if(cDetail is PathCard){
            if (boardDetail.checkValid(p,cloest_j, cloest_i))
            {
                boardDetail.setGrid(cloest_j, cloest_i, this.transform.Find("Image").GetComponent<Image>().sprite, this.transform.GetComponent<Property>());
                GameManager.Instance.currRound.currPlayer.Discard(this.gameObject);
                boardDetail.RevealDes(cloest_j,cloest_i);
            }
            else
            {
                if(boardDetail.CheckDes(p,cloest_j,cloest_i)){
                    boardDetail.setGrid(cloest_j, cloest_i, this.transform.Find("Image").GetComponent<Image>().sprite, this.transform.GetComponent<Property>());
                    GameManager.Instance.currRound.currPlayer.Discard(this.gameObject);   
                    boardDetail.RevealDes(cloest_j,cloest_i);
                }
                else
                {
                    this.transform.SetParent(parentToReturnTo);
                }
            //Debug.Log(this.transform.parent.name);
            
            }
        }else if (cDetail is Destroy_PathCard){
            if ((cloest_i == 8 && (cloest_j == 0 || cloest_j == 2 || cloest_j == 4)) || (cloest_i == 0 && cloest_j == 2))
            {
                this.transform.SetParent(parentToReturnTo);
                return;
            }
            
            if(closest.used){
                Debug.Log("Destroying this path");
                ((Destroy_PathCard)cDetail).Apply(closest);
                GameManager.Instance.currRound.currPlayer.Discard(this.gameObject);
            }
            else
            {
                this.transform.SetParent(parentToReturnTo);
            }
        } else if (cDetail is Show_Destination){
            if ((cloest_i == 8 && (cloest_j == 0 || cloest_j == 2 || cloest_j == 4)))
            {
                ((Show_Destination)cDetail).Apply(closest);
                GameManager.Instance.currRound.currPlayer.Discard(this.gameObject);
            }else{
                this.transform.SetParent(parentToReturnTo);
            }
        }
        
    }

    
    //need to  be change to accept card property instead and need to move to boaard script 
    
}
