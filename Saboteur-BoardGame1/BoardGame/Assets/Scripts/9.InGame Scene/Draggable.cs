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
        
        Debug.Log(checkValid(cloest_j, cloest_i));
        //transform card's data to path
        boardDetail.setGrid(cloest_j, cloest_i, this.gameObject.GetComponent<Image>().sprite, this.transform.GetComponent<Property>());
        /*board[cloest_j, cloest_i].transform.GetComponent<Property>().center = this.transform.GetComponent<Property>().center;
        board[cloest_j, cloest_i].transform.GetComponent<Property>().Down = this.transform.GetComponent<Property>().Down;
        board[cloest_j, cloest_i].transform.GetComponent<Property>().Up = this.transform.GetComponent<Property>().Up;
        board[cloest_j, cloest_i].transform.GetComponent<Property>().Left = this.transform.GetComponent<Property>().Left;
        board[cloest_j, cloest_i].transform.GetComponent<Property>().Right = this.transform.GetComponent<Property>().Right;
        board[cloest_j, cloest_i].transform.GetComponent<Property>().used = true;
        //transform the card's image to the path
        
        board[cloest_j, cloest_i].gameObject.GetComponent<Image>().sprite = this.gameObject.GetComponent<Image>().sprite;*/
        //Destroy the card object.
        //need valid checking code here
        
        //Confirm card move
        GameManager.Instance.currentRound.GetComponent<Round>().currentPlayer.GetComponent<PlayerController>().PlayCard(this.gameObject);
        Destroy(this.gameObject);
    }
    public bool checkValid( int x, int y)
    {
        PathCard c = (PathCard)this.GetComponent<Card>().card;

        if (board[x, y] == null)//if the position is blank
        {
            GameObject left = board[x - 1, y];//left card to this card
            GameObject below = board[x, y - 1];//below card to this card
            GameObject right = board[x + 1, y];//right card to this card
            GameObject above = board[x, y + 1];// above card to this card

            bool valid = true;
            if (c.right != right.GetComponent<Property>().Left)
            {
                valid = false;
            }
            else if (c.left != left.GetComponent<Property>().Right)
            {
                valid = false;
            }
            else if (c.up != above.GetComponent<Property>().Down)
            {
                valid = false;
            }
            else if (c.down != below.GetComponent<Property>().Up)
            {
                valid = false;
            }
            return valid;
        }

        return false;

    }
}
