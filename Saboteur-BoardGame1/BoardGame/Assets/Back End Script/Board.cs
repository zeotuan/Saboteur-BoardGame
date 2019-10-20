//this is just a testing script i wrote for reference (not for our game and does not work)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;
public class Board : MonoBehaviour
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
    public List<Property> usedGridproperty;
    [SerializeField]
    int xTrueDes, yTrueDes;

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

    public void GenerateBoard(int numPlayer, int maxCol, int maxRow)
    {
        //Destroy existed GridObject
        board = new GameObject[maxRow, maxCol];
        if(board.Length > 0){
            for (int r = 0; r < maxRow; r++) { 
                for(int c = 0; c < maxCol; c++)
                {
                    Destroy(board[r,c]);  
                }
            }
        }   
        shuffleDestination();
        //GameManager.Instance.shuffle(DesGrid);
        for (int r = 0; r < maxRow; r++) { 
            for(int c = 0; c < maxCol; c++)

            {
                for (int c = 0; c < maxCol; c++)
                {
                    Destroy(board[r, c]);
                }
            }
            shuffleDestination();
            //GameManager.Instance.shuffle(DesGrid);
            for (int r = 0; r < maxRow; r++)
            {
                for (int c = 0; c < maxCol; c++)
                {

                    GameObject tile;
                    if (r == 2 && c == 0)
                    {
                        tile = Instantiate(startGrid) as GameObject;
                    }
                    else if (r == 0 && c == 8)
                    {
                        tile = Instantiate(DesGrid[0]) as GameObject;
                    }
                    else if (r == 2 && c == 8)
                    {
                        tile = Instantiate(DesGrid[1]) as GameObject;
                    }
                    else if (r == 4 && c == 8)
                    {
                        tile = Instantiate(DesGrid[2]) as GameObject;
                    }
                    else
                    {
                        tile = Instantiate(GridPrefab) as GameObject;
                    }


                    if (tile.name == "TrueDes Variant(Clone)")
                    {
                        xTrueDes = r;
                        yTrueDes = c;
                    }



                    float posX = c * tileSize;
                    float posY = r * tileSize;
                    tile.transform.position = new Vector3(posX, posY, transform.position.z);
                    tile.transform.SetParent(transform);
                    board[r, c] = tile;
                    tile.GetComponent<Property>().x = r;
                    tile.GetComponent<Property>().y = c;
                }

            }
        }

    }

    public GameObject findNearestGrid(GameObject card)
    {
        GameObject nearestGrid = null;
        float distance = Vector3.Distance(card.transform.position, board[0, 0].transform.position);
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
                        nearestGrid = board[j, i];
                    }

                }
            }
        }
        return nearestGrid;
    }

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
        grid.center = setProperty.center;
        board[x, y].GetComponent<Image>().sprite = img;
        if (setProperty.rotated)
        {
            board[x, y].GetComponent<Image>().transform.Rotate(Vector3.forward * -180);
        }
        usedGridproperty.Add(grid);
        var tempColor = board[x, y].GetComponent<Image>().color;
        tempColor.a = 1f;
        tempColor = Color.white;
        board[x, y].GetComponent<Image>().color = tempColor;



    }

    public bool BreadthFirstSearch(int x, int y)
    {
        if (x == xTrueDes && y == yTrueDes)
        {
            return true;
        }
        bool[,] visited = new bool[5, 9];

        Queue<Property> queue = new Queue<Property>();
        queue.Enqueue(board[x,y].GetComponent<Property>());
        
        while(queue.Count > 0)
        {
            Property current = queue.Dequeue();
            visited[current.x, current.y] = true;
            Debug.Log("current: " + current.x + " " + current.y);
            List<Property> ReachableList = Getreachable(current);
            foreach(Property next in ReachableList)
            {
                
                if (next.x == xTrueDes && next.y == yTrueDes)
                {
                    return true;
                }
                if(!visited[next.x, next.y])
                {
                    queue.Enqueue(next);
                }
            }
        }
        return false;
    }

    //Get Reachable path from inputted path
    public List<Property> Getreachable(Property property)
    {
        List<Property> reachableList = new List<Property>();
        Property up, down, left, right;
        if (property.x != 0)
        {
            up = board[property.x - 1, property.y].GetComponent<Property>();
            if(up.Down && property.Up && up.center)//need to check center since though without the center will not lead to anywhere else even thought path can still be placed next to them  
            {
                reachableList.Add(up);
                Debug.Log("reachable: " + up.x + " " + up.y);
            }
        }

        if (property.y != 8)
        {
            right = board[property.x, property.y+1].GetComponent<Property>();
            if (right.Left && property.Right && right.center)
            {
                reachableList.Add(right);
                Debug.Log("reachable: " + right.x + " " + right.y);
            }
        }
        if (property.y != 0)
        {
            left = board[property.x, property.y-1].GetComponent<Property>();
            if (left.Right && property.Left && left.center)
            {
                reachableList.Add(left);
                Debug.Log("reachable: " + left.x + " " + left.y);
            }
        }
        if (property.x!=4)
        {
            down = board[property.x + 1, property.y].GetComponent<Property>();
            if (down.Up && property.Down && down.center)
            {
                reachableList.Add(down);
                Debug.Log("reachable: " + down.x + " " + down.y);
            }
        }
        return reachableList;
    }

    //get possible available position that can placed card above it 
    public List<Property> GetPossibleUpPosition(){
        List<Property> possibleUpList = new List<Property>();
        foreach(Property prop in usedGridproperty){
            if(prop.x==0){
                continue;
            }
            Property upGrid = board[prop.x-1,prop.y].GetComponent<Property>();
            if(prop.Up && !upGrid.used){//there a way up and up is not used
                possibleUpList.Add(upGrid);
            }
        }
        return possibleUpList;
    }

    //get possible available position that can placed card below it 
    public List<Property> GetPossibleDownPosition( ){
        List<Property> possibleDownList = new List<Property>();
        foreach(Property prop in usedGridproperty){
            if(prop.x == 4){
                continue;
            }
            Property downGrid = board[prop.x+1,prop.y].GetComponent<Property>();
            if(prop.Up && !downGrid.used){//there a way up and up is not used
                possibleDownList.Add(downGrid);
            }
        }
        return possibleDownList;
    }

    //get possible available position that card can be plalced on the right of it 
    public List<Property> GetPossibleRightPosition( ){
        List<Property> possibleRightList = new List<Property>();
        foreach(Property prop in usedGridproperty){
            if(prop.y == 8){
                continue;
            }
            Property rightGrid = board[prop.x,prop.y+1].GetComponent<Property>();
            if(prop.Up && !rightGrid.used){//there a way up and up is not used
                possibleRightList.Add(rightGrid);
            }
        }
        return  possibleRightList;
    }

    //get possible available position that can placed card on the left of it 
    public List<Property> GetPossibleLeftPosition( ){
        List<Property> possibleLeftList = new List<Property>();
        foreach(Property prop in usedGridproperty){
            if(prop.y == 0){
                continue;
            }
            Property leftGrid = board[prop.x,prop.y-1].GetComponent<Property>();
            if(prop.Up && !leftGrid.used){//there a way up and up is not used
                possibleLeftList.Add(leftGrid);
            }
        }
        return  possibleLeftList;
    }

    public bool checkValid(Property c, int x, int y)
    {
        Property left;
        Property up;
        Property right;
        Property down;
        bool valid = false;
        if (x != 0)
        {
            up = board[x - 1, y].GetComponent<Property>();
            if (up.Down && c.Up)
            {
                valid = true; Debug.Log("Valid Card Placed at position:" + up.x + up.y);
                //CheckDes(up);
            }
            if (up.Down != c.Up && up.used)
            {
                return false;
            }
        }

        if (x != 4)
        {
            down = board[x + 1, y].GetComponent<Property>();
            if (down.Up && c.Down)
            {
                valid = true; Debug.Log("Valid Card Placed at position:" + down.x + down.y);
                //CheckDes(down);
            }
            if (down.Up != c.Down && down.used)
            {
                return false;
            }
        }

        if (y != 8)
        {
            right = board[x, y + 1].GetComponent<Property>();
            if (right.Left && c.Right)
            {
                valid = true; Debug.Log("Valid Card Placed at position:" + right.x + right.y);
                //CheckDes(eight);
            }
            if (right.Left != c.Right && right.used)
            {
                return false;
            }
            
        }

        if (y != 0)
        {
            left = board[x, y - 1].GetComponent<Property>();
            if (left.Right && c.Left)
            {
                valid = true; Debug.Log("Valid Card Placed at position:" + left.x +" "+ left.y);

            }
            if (left.Right != c.Left && left.used)
            {
                return false;
            }
        }
        //then check if the placed card compatible with any other path
        return valid;

    }

    public void CheckDes(Property prop)
    {
        if(prop.y == 8 && (prop.x == 0 || prop.x ==2 || prop.x == 4))
        {
            //reveal card 
        }    
    }

}

    

