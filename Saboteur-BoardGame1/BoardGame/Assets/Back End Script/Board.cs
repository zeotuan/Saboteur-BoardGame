//this is just a testing script i wrote for reference (not for our game and does not work)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Board : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    //2 dimensional array for cards on board 
    public GameObject GridPrefab;
    [SerializeField]
    public GameObject[,] board;
    private Vector2 mouseOver;
    private Card SelectedCard;
    private Vector2 StartDrag;
    private Vector2 EndDrag;
    [SerializeField]
    private float tileSize = 1;
    public GameObject startGrid;
    public GameObject[] DesGrid;

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

    private void UpdateMouseOver()
    {
        //if it's my turn
        if (!Camera.main)
        {// if camera does not exist 
            Debug.Log("unable to find camera");
            return;
        }
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("Board")))
        {
            mouseOver.x = (int)hit.point.x;
            mouseOver.y = (int)hit.point.z;
            Debug.Log("x:" + mouseOver.x + " y:" + mouseOver.y);
        }
        else
        {
            mouseOver.x = -1;
            mouseOver.y = -1;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        GenerateBoard(5, 9, 5);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouseOver();
        //if it is my turn
        int x = (int)mouseOver.x;
        int y = (int)mouseOver.y;
    }

    private void GenerateBoard(int numPlayer, int maxCol, int maxRow)
    {
        board = new GameObject[maxRow, maxCol];
        shuffleDestination();
        for (int r = 0; r < maxRow; r++) { 
            for(int c = 0; c < maxCol; c++)
            {
                GameObject tile;
                if (r==2 && c==0)
                {
                    tile = Instantiate(startGrid) as GameObject;
                }else if (r==0 && c==8)
                {
                    tile = Instantiate(DesGrid[0]) as GameObject;
                }else if (r==2 && c==8)
                {
                    tile = Instantiate(DesGrid[1]) as GameObject;
                } else if (r==4 && c==8)
                {
                    tile = Instantiate(DesGrid[2]) as GameObject;
                }
                else
                {
                    tile = Instantiate(GridPrefab) as GameObject;
                }
                
                float posX = c * tileSize;
                float posY = r * tileSize;
                tile.transform.position = new Vector3(posX, posY, transform.position.z);
                tile.transform.SetParent(transform);
                board[r, c] = tile;
            }
        }
        
        //float gridH = maxCol * tileSize;
        //float gridW = maxRow * tileSize;

        

        //transform.position = new Vector3(-gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2);

    }

    /*public bool checkValid(Card c, int x, int y)
    {
        if (c.card is PathCard) { 
            return ((PathCard)c.card).checkValid(board, x, y);
        }
        else
        {
         
        }
        return false;
    }*/

    private void shuffleDestination()
    {
        for (int i = 0; i < DesGrid.Length; i++)
        {
            var container = DesGrid[i];
            int randomIndex = Random.Range(i, DesGrid.Length);
            DesGrid[i] = DesGrid[randomIndex];
            DesGrid[randomIndex] = container;
        }
    }
     
    public PlayerController chooseTarget(PlayerController target)
    {
        return target;
    }

    public void setGrid(int x, int y, Sprite img,Property setProperty)
    {
        Property grid = board[x, y].GetComponent<Property>();
        grid.used = true;
        grid.Up = setProperty.Up;
        grid.Down = setProperty.Down;
        grid.Left = setProperty.Left;
        grid.Right = setProperty.Right;
        board[2, 0].GetComponent<Image>().sprite = img;
    }
}

    

