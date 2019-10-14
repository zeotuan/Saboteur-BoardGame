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

        if (this.transform.parent != this.transform.parent.Find("Map"))
        {
            this.transform.SetParent(this.transform.parent.Find("Map"));
        }
        else
        {
            this.transform.SetParent(parentToReturnTo);
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
            /*
            this.transform.parent.parent.Find("Handle/Buttons/Confirm").gameObject.SetActive(true);
            
            Debug.Log(this.transform.name);
            this.transform.parent.Find("Canvas/Panel/Buttons/Rotate").gameObject.SetActive(true);
            
            this.transform.parent.parent.Find("Handle/Buttons/Cancel").gameObject.SetActive(true);
            
            this.transform.parent.Find("Buttons/Discard").gameObject.SetActive(false);
            this.transform.parent.Find("Buttons/Rotate").GetComponent<Dropped_path>().setSelectedPath(board[cloest_j, cloest_i]); */
            

            boardDetail.setGrid(cloest_j, cloest_i, this.gameObject.GetComponent<Image>().sprite, this.transform.GetComponent<Property>());
            GameManager.Instance.currentRound.GetComponent<Round>().currentPlayer.GetComponent<PlayerController>().Discard(this.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            //Debug.Log(this.transform.parent.name);
            this.transform.SetParent(parentToReturnTo);
        }
    }

    
    //need to  be change to accept card property instead and need to move to boaard script 
    
}
