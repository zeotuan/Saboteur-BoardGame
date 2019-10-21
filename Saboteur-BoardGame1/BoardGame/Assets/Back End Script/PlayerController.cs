//add this to player prefab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Transform cardHolder;
    public Transform playerHolder;
    public Transform currentPlayerHolder;
    public GameObject PlayerHolderPrefab;
    public string playerName;
    [SerializeField]
    public List<GameObject> hand;//list of card 
    //StateMachine StateMachine = new StateMachine();
    public bool PickAxe;
    public bool Lamb;
    public bool Cart;
    [SerializeField]
    private bool MyTurn;
    [SerializeField]
    private bool FinishTurn;
    private int Point;
    [SerializeField]
    private string role;
    private bool IsBot;
    [SerializeField]
    private List<int> Points = new List<int>();
    [SerializeField]
    private List<string> Role = new List<string>();
    [SerializeField]
    private GameObject playerInformation;

    public Sprite B_PickAxe;
    public Sprite N_PickAxe;
    public Sprite B_Lamb;
    public Sprite N_Lamb;
    public Sprite B_Cart;
    public Sprite N_Cart;
    public Sprite Role_back;
    public Sprite dwarf;
    public Sprite sabotour;

    void Start()
    {
        cardHolder = GameObject.Find("Cards").transform;
        playerHolder = GameObject.Find("Left").transform;
        currentPlayerHolder = GameObject.Find("Bottom_Left").transform;
        playerInformation = Instantiate(PlayerHolderPrefab) as GameObject;
        playerInformation.transform.SetParent(playerHolder);
        this.gameObject.transform.SetParent(playerInformation.transform);
        playerInformation.transform.Find("Player's name").GetComponent<Text>().text = playerName;
        playerInformation.name = this.name;
        //StateMachine.ChangeState()
    }
    
    public void Update()
    {   


        //StateMachine.Update();    
        if (MyTurn)
        {
            if (IsBot)
            {
                BotPlay();
            }
        }
        else
        {
            //
        }
    }

    public void StartTurn()
    {
        MyTurn = true;
        foreach (GameObject card in hand)
        {
            card.SetActive(true);
            card.transform.SetParent(cardHolder);
            playerInformation.transform.SetParent(currentPlayerHolder);
            card.GetComponent<activate>().enabled = true;
        }
        this.transform.parent.Find("Role").gameObject.SetActive(true);
        this.transform.parent.Find("Panel").GetComponent<Button>().enabled = false;
        if (this.getRole() == "dwarf")
        {
            //Debug.Log("Dwarf");
            //Debug.Log(this.transform.parent.name);
            this.transform.parent.Find("Panel").GetComponent<Image>().sprite = dwarf;
        }
        else
        {
            //Debug.Log("Sabotour");
            //Debug.Log(this.transform.parent.name);
            this.transform.parent.Find("Panel").GetComponent<Image>().sprite = sabotour;
        }
    }

    public void EndTurn()
    {
        MyTurn = false;
        foreach (GameObject card in hand)
        {
            card.GetComponent<activate>().enabled = false;
            card.transform.SetParent(transform);
            card.SetActive(false);
            playerInformation.transform.SetParent(playerHolder);
        }
        this.transform.parent.Find("Panel").GetComponent<Button>().enabled = true;
        this.transform.parent.Find("Role").gameObject.SetActive(false);
        this.transform.parent.Find("Panel").GetComponent<Image>().sprite = Role_back;
    }

    public void Discard(GameObject card)
    {
        hand.Remove(card);
        Destroy(card);
        FinishTurn = true;
    }
    

    public bool Played()
    {
        if (FinishTurn)
        {
            FinishTurn = false;
            return true;
        }
        return FinishTurn;
    }

    public void setRole(string role)
    {
        this.role = role;
    }
    public string getRole()
    {
        return this.role;
    }
    public void addRole(string role){
        Role.Add(role);
    }

    public void addPoint(int point){
        Points.Add(point);
    }

    public int getPoint()
    {
        int totalPoint = 0;
        foreach(int point in Points)
        {
            totalPoint += point;
        }
        return totalPoint;
    }

    public void UpdateEffectPanel()
    {
        if (PickAxe)
        {
            //playerInformation.transform.GetChild(10).GetComponent<>
            playerInformation.transform.Find("Image (1)").GetComponent<Image>().sprite = N_PickAxe;

        }
        else
        {
            playerInformation.transform.Find("Image (1)").GetComponent<Image>().sprite = B_PickAxe;
        }
        if (Cart)
        {
            playerInformation.transform.Find("Image (2)").GetComponent<Image>().sprite = N_Cart;
        }
        else
        {
            playerInformation.transform.Find("Image (2)").GetComponent<Image>().sprite = B_Cart;
        }
        if (Lamb)
        {
            playerInformation.transform.Find("Image (3)").GetComponent<Image>().sprite = N_Lamb;
        }
        else
        {
            playerInformation.transform.Find("Image (3)").GetComponent<Image>().sprite = B_Lamb;
        }
    }


    public void BotPlay()
    {
        
        Board board =  GameObject.Find("Map").GetComponent<Board>();
        foreach(GameObject card in hand){
            CardDetail c = card.GetComponent<Card>().card;
            if(c is PathCard){
                Property cardProp = card.GetComponent<Property>();
                /*
                if(cardProp.Left){// if this card can be put on the right of some other card 
                    foreach(Property prop in board.GetPossibleRightPosition()){
                        if(checkValid(cardProp,prop.x, prop.y)){
                            board.setGrid(prop.x, prop.y, cardProp);
                            Discard(card);
                            return;
                        }
                    }
                }
                if (cardProp.Right){
                    foreach(Property prop in board.GetPossibleLeftPosition()){
                        if(checkValid(cardProp,prop.x, prop.y)){
                            board.setGrid(prop.x, prop.y, cardProp);
                            Discard(card);
                            return;
                        }
                    }
                }
                if (cardProp.Up){
                    foreach(Property prop in board.GetPossibleDownPosition()){
                        if(checkValid(cardProp,prop.x, prop.y)){
                            board.setGrid(prop.x, prop.y, cardProp);
                            Discard(card);
                            return;
                        }
                    }
                }
                if (cardProp.Down){
                    foreach(Property prop in board.GetPossibleUpPosition()){
                        if(checkValid(cardProp,prop.x, prop.y)){
                            board.setGrid(prop.x, prop.y, cardProp);
                            Discard(card);
                            return;
                        }
                    }
                } 
                */
            }
            else
            {
                //
                if(c is FixCard)
                {
                    ((FixCard)c).Apply(GameManager.Instance.Players[Random.Range(0, 4)].GetComponent<PlayerController>());  
                }
                else
                {
                    ((EffectCard)c).Apply(GameManager.Instance.Players[Random.Range(0, 4)].GetComponent<PlayerController>());
                    

                }
                
                Discard(card);
                return;
            }
        }
    }

    
}
