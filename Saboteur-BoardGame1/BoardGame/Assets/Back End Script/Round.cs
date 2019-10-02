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
    float TimeLeft = 20;
    string[] roles;
    void Start()
    {
        //shufflePlayer();
        //shuffleRole();
        
        /*GameManager.Instance.shuffle(roles);
        GameManager.Instance.shuffle(GameManager.Instance.Players);*/
        if (!RoundStarted)
        {
            Turn = 0;
            int count = 0;
            
            foreach(GameObject player in GameManager.Instance.Players)
            {
                GameManager.Instance.deck.GetComponent<Deck>().Deal(player.GetComponent<PlayerController>(), RoundStarted);
                //player.GetComponent<PlayerController>().setRole(roles[count]);

            }
            count++;
            currentPlayer.GetComponent<PlayerController>().StartTurn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        GameObject.Find("Canvas/Time left").GetComponent<Time_Record>().time = TimeLeft;
        if(TimeLeft > 20)
        {
            //PrepareToSwitchTurnPanel.Raise();
        }
        if(TimeLeft <= 0)
        {
            if(currentPlayer.GetComponent<PlayerController>().hand.Count > 4)
            {
                currentPlayer.GetComponent<PlayerController>().Discard(currentPlayer.GetComponent<PlayerController>().hand[4]);
            }
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
        TimeLeft = 30;
        RoundStarted = true;
        GameManager.Instance.deck.GetComponent<Deck>().Deal(currentPlayer.GetComponent<PlayerController>(), RoundStarted);
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
        if(board.BreadthFirstSearch(2, 0))
        {
            return 1;
        }
        else
        {
            if (GameManager.Instance.deck.GetComponent<Deck>().deck.Count == 0)
            {
                return -1;
            }
                
        }
        return 0;
        
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
