using UnityEngine.SceneManagement;
using UnityEngine;

public class Round : MonoBehaviour
{
    bool RoundStarted;
    public int Turn;
    public GameObject currentPlayer { get { return GameManager.Instance.Players[Turn]; } }
    bool ThisRoundTurn = false;
    bool roundEnd = false;
    [SerializeField]
    float TimeLeft = 10;
    [SerializeField]
    string[] roles;
    void Start()
    {
        shufflePlayer();
        shuffleRole();
        
        /*GameManager.Instance.shuffle(roles);
        GameManager.Instance.shuffle(GameManager.Instance.Players);*/
        if (!RoundStarted)
        {
            Turn = 0;
            int count = 0;
            for(int i = 0; i < 5; i++){//deal 5 card to each player when starting the round
                foreach(GameObject player in GameManager.Instance.Players)
                {
                    GameManager.Instance.deck.GetComponent<Deck>().Deal(player.GetComponent<PlayerController>());
                }
            }
            foreach (GameObject player in GameManager.Instance.Players)
            {
                player.GetComponent<PlayerController>().setRole(roles[count]);
                count++;
            }
            

            currentPlayer.GetComponent<PlayerController>().StartTurn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        GameObject.Find("Canvas/Time left").GetComponent<Time_Record>().time = TimeLeft;
        if(TimeLeft > 5)
        {
            //PrepareToSwitchTurnPanel.Raise();
        }
        if(TimeLeft <= 0)//out of time without playing anycard
        {
                int index = Random.Range(0, currentPlayer.GetComponent<PlayerController>().hand.Count);
                currentPlayer.GetComponent<PlayerController>().Discard(currentPlayer.GetComponent<PlayerController>().hand[index]);
            
        }
        if (currentPlayer.GetComponent<PlayerController>().Played())
        {
            SwitchTurn();
        }   

    }

    public void StartRound()
    {
        ThisRoundTurn = true;
        Turn = 0;
    }

    
    public void SwitchTurn()
    {
        TimeLeft = 11;
        RoundStarted = true;
        GameManager.Instance.deck.GetComponent<Deck>().Deal(currentPlayer.GetComponent<PlayerController>());
        currentPlayer.GetComponent<PlayerController>().EndTurn();
        if (checkWinCondition() == 1 || checkWinCondition() == -1)
        {
            roundEnd = true;
            EndRound();
            return;
        }
        Turn++;
        if (Turn == GameManager.Instance.Players.Count)
        {
            Turn = 0;    
        }
        currentPlayer.GetComponent<PlayerController>().StartTurn();
        
    }

    int checkWinCondition()
    {
        Board board = GameObject.Find("Map").GetComponent<Board>();

        if(board.BreadthFirstSearch(2, 0))// if there is a path from start to goal
        {
            return 1;//Goal digger win
        }
        else//there is no path from start to goal
        {
            if (GameManager.Instance.deck.GetComponent<Deck>().deck.Count == 0)//there no card left 
            {
                return -1;//saboteur win
            }
              
        }
        return 0;// no group has won
        
    }

    public void EndRound()
    {
        ThisRoundTurn = false;
    }

    
    void shufflePlayer()
    {
        for (int i = 0; i < GameManager.Instance.Players.Count; i++)
        {
            var container = GameManager.Instance.Players[i];
            int randomIndex = Random.Range(i, GameManager.Instance.Players.Count);
            GameManager.Instance.Players[i] = GameManager.Instance.Players[randomIndex];
            GameManager.Instance.Players[randomIndex] = container;
        }
    }

    void shuffleRole()
    {
        for (int i = 0; i < roles.Length; i++)
        {
            var container = roles[i];
            int randomIndex = Random.Range(i, roles.Length);
            roles[i] = roles[randomIndex];
            roles[randomIndex] = container;
        }
    }
}
