//this is just a testing script i wrote for reference (not for our game and does not work)
//does not add this to any gameObject
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager1 : MonoBehaviour
{
    //2 dimensional array for cards on board 
    private Card[,] cards;
    private Card[] hand;
    private Card[] deck;
    private Vector3 boardOffset = new Vector3(-4.0f,0,-0.4f);
    private Vector2 mouseOver;
    private Card SelectedCard;
    private Vector2 StartDrag;
    private Vector2 EndDrag;



    // Start is called before the first frame update
    void Start()
    {
        GenerateBoard(5,9,5);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouseOver();
        //if it is my turn
        int x = (int)mouseOver.x;
        int y = (int)mouseOver.y;

        if (SelectedCard != null)
            UpdateCardMove(SelectedCard);
        if(Input.GetMouseButtonDown(0))
            SelectCard(x,y);

        if(Input.GetMouseButtonUp(0))
            TryMove((int)StartDrag.x, (int)StartDrag.y,x,y);
    }



    private void UpdateMouseOver(){
        //if it's my turn
        if(!Camera.main){// if camera does not exist 
            Debug.Log("unable to find camera");
            return;
        }
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, 25.0f,LayerMask.GetMask("Board"))){
            mouseOver.x = (int)hit.point.x;
            mouseOver.y = (int)hit.point.z;
        }else{
            mouseOver.x = -1;
            mouseOver.y = -1;
        }

    }

    private void SelectCard(int x, int y){
            //out of bound 
            if(x < 0 || x >=cards.Length|| y < 0 || y >= cards.Length){
                return;
            }
            Card c = cards[x,y];
            if(c != null){
                SelectedCard = c;
                StartDrag = mouseOver;
            }
            
    }

    private void TryMove(int x1, int y1, int x2, int y2){
        StartDrag = new Vector2(x1,y1);
        EndDrag = new Vector2(x2,y2);
        SelectedCard = cards[x1,y1];
        if(x2 < 0 || x2 >= cards.Length || y2 < 0 || y2 >= cards.Length){
            if(SelectedCard != null){
                MoveCard(SelectedCard, x1,y1);
            }
            SelectedCard = null;
            StartDrag = Vector2.zero;
            return;
        }

        if(SelectedCard != null){
            if(EndDrag == StartDrag){
                MoveCard(SelectedCard,x1,y1);
                SelectedCard = null;
                StartDrag = Vector2.zero;
                return;
            }

        }
        MoveCard(SelectedCard, x2,y2);
    }

    private void UpdateCardMove(Card c){
        if(!Camera.main){// if camera does not exist 
            Debug.Log("unable to find camera");
            return;
        }
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, 25.0f,LayerMask.GetMask("Board"))){
            c.transform.position = hit.point+Vector3.up;
        }
    }
     
    private void GenerateBoard(int numPlayer, int maxCol, int maxRow){
        cards = new Card[maxRow,maxCol];
    }

    private void MoveCard(Card c, int x, int y){
        c.transform.position = (Vector3.right * x) + (Vector3.forward * y) + boardOffset;
    }
}
