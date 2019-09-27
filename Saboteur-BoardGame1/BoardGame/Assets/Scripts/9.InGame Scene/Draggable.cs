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
        if (!this.GetComponent<Card>().Interactalbe)
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

        //Debug.Log(checkValid(cloest_j, cloest_i));
        //transform card's data to path
        //Debug.Log(board[cloest_j, cloest_i].transform.Find("Confirm").gameObject.SetActive(true));
        //board[cloest_j, cloest_i].transform.Find("Confirm").gameObject.SetActive(true);
        //board[cloest_j, cloest_i].transform.Find("Rotate").gameObject.SetActive(true);
        //this.transform.parent.Find("Discard").gameObject.SetActive(true);
        this.transform.parent.parent.Find("Handle/Buttons/Confirm").gameObject.SetActive(true);
        this.transform.parent.parent.Find("Handle/Buttons/Rotate").gameObject.SetActive(true);
        this.transform.parent.parent.Find("Handle/Buttons/Cancel").gameObject.SetActive(true);
        this.transform.parent.parent.Find("Handle/Buttons/Discard").gameObject.SetActive(false);

        this.transform.parent.parent.Find("Handle/Buttons/Rotate").GetComponent<Dropped_path>().setSelectedPath(board[cloest_j, cloest_i]); 
        

        boardDetail.setGrid(cloest_j, cloest_i, this.gameObject.GetComponent<Image>().sprite, this.transform.GetComponent<Property>());
        //Destroy the card object.
        //need valid checking code here
        
        //Confirm card move
        GameManager.Instance.currentRound.GetComponent<Round>().currentPlayer.GetComponent<PlayerController>().PlayCard(this.gameObject);
        Destroy(this.gameObject);
    }
    public GameObject findNearestGrid()
    {
        GameObject nearestGrid = null;

        return nearestGrid;
    }

    public bool checkValid( int x, int y)
    {
        PathCard c = (PathCard)this.GetComponent<Card>().card;
        Property left;
        Property up;
        Property right;
        Property down;
        bool valid = false;
        if (x != 0)
        {
            up = board[x - 1, y].GetComponent<Property>();
            if (up.Down && c.up)
            {
                valid = true;    
            }
            if(up.Down != c.up)
            {
                return false;
            }
        }

        if (y != 8)
        {
            right = board[x, y + 1].GetComponent<Property>();
            if (right.Left && c.right)
            {
                valid = true;
            }
            if(right.Left != c.right)
            {
                return false;
            }
        }
        if (y != 0)
        {
            left = board[x, y - 1].GetComponent<Property>();
            if (left.Right && c.left)
            {
                valid = true;
            }
            if(left.Right != c.left)
            {
                return false;
            }
        }
        if (x!=4)
        {
            down = board[x + 1, y].GetComponent<Property>();
            if (down.Up && c.down)
            {
                valid = true;
            }
            if(down.Up != c.down)
            {
                return false;
            }
        }
        //then check if the placed card compatible with any other path
        return valid;

    }
}
