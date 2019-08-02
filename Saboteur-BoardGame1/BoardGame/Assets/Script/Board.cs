//this is just a testing script i wrote for reference (not for our game and does not work)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Board : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
    public void OnDrop(PointerEventData eventData)
    {
        DragS d = eventData.pointerDrag.GetComponent<DragS>();
        if (d != null)
        {
            d.parentToReturnTo = this.transform;
        }
    }

    //2 dimensional array for cards on board 
    private Card[,] board;
    private Vector2 mouseOver;
    private Card SelectedCard;
    private Vector2 StartDrag;
    private Vector2 EndDrag;



    // Start is called before the first frame update
    void Start()
    {
        GenerateBoard(5, 9, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //if it is my turn
        int x = (int)mouseOver.x;
        int y = (int)mouseOver.y;

        if (SelectedCard != null)
            UpdateCardMove(SelectedCard);
        if (Input.GetMouseButtonDown(0))
            SelectCard(x, y);

        if (Input.GetMouseButtonUp(0))
            TryMove((int)StartDrag.x, (int)StartDrag.y, x, y);
    }



    

    private void SelectCard(int x, int y)
    {
        //out of bound 
        if (x < 0 || x >= board.Length || y < 0 || y >= board.Length)
        {
            return;
        }
        Card c = board[x, y];
        if (c != null)
        {
            SelectedCard = c;
            StartDrag = mouseOver;
        }

    }

    private void TryMove(int x1, int y1, int x2, int y2)
    {
        StartDrag = new Vector2(x1, y1);
        EndDrag = new Vector2(x2, y2);
        SelectedCard = board[x1, y1];
        if (x2 < 0 || x2 >= board.Length || y2 < 0 || y2 >= board.Length)
        {
            if (SelectedCard != null)
            {
                MoveCard(SelectedCard, x1, y1);
            }
            SelectedCard = null;
            StartDrag = Vector2.zero;
            return;
        }

        if (SelectedCard != null)
        {
            if (EndDrag == StartDrag)
            {
                MoveCard(SelectedCard, x1, y1);
                SelectedCard = null;
                StartDrag = Vector2.zero;
                return;
            }

        }
        MoveCard(SelectedCard, x2, y2);
    }

    private void UpdateCardMove(Card c)
    {
        if (!Camera.main)
        {// if camera does not exist 
            Debug.Log("unable to find camera");
            return;
        }
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("Board")))
        {
            c.transform.position = hit.point + Vector3.up;
        }
    }

    private void GenerateBoard(int numPlayer, int maxCol, int maxRow)
    {
        board = new Card[maxRow, maxCol];
    }

    private void MoveCard(Card c, int x, int y)
    {
        c.transform.position = (Vector3.right * x) + (Vector3.forward * y);

    }
}
