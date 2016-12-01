using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public Ball ball;//the pong ball
    public Transform player1; // player1's paddle
    public Transform player2; //player2's paddle, Also used by the AI in single player
    public float paddleSpeed = 10.0f; //how quickly the player's paddle can be moved
    public bool multiplayer = false; // is the gamemultiplayer
    public float AIErrorRange = 5; //how accurate the AI is. higher values will cause the AI to miss more
    public float AISpeed = 10; //how quickly the AI can move the paddle
    public float winScore = 5; // score necessary to win the game
    public Text p1ScoreText, p2ScoreText; // the display for the current score
    public Text winText; //the text to display the victory message after a player has won
    public GameObject menu; // the start menu UI
    public GameObject console; // the console UI panel
    public GameObject background; // the background of the playing field
    public float mapWidth = 20; // how wide the map is. Used to convert tap position to ingame location for touch controls

    private string mainMessage = ""; //main text message. 
    private int player1Score = 0; //current score for player 1
    private int player2Score = 0; //current score for player 2
    private Vector3 ballStartPosition; // the position of the ball should start from when the game starts
    private float AIError;  //how accurate the AI is for the current exchange.

    // Use this for initialization
    void Start () {
        ballStartPosition = ball.transform.position;
        updateAIError();
        Time.timeScale = 0;
        console.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        manageMenu();

        if (Input.touchCount > 0) {

            Vector3 fingerPos = Input.GetTouch(0).position;
            float moveDir = ((fingerPos.y - Screen.height / 2) / Screen.height) * mapWidth;
            player1.position = new Vector3(player1.position.x, player1.position.y, moveDir);
        }

        player1.Translate(Vector3.forward * Input.GetAxis("Player1") * paddleSpeed * Time.deltaTime);

        if (multiplayer == true)
            player2.Translate(Vector3.forward * Input.GetAxis("Player2") * paddleSpeed * Time.deltaTime);
        else
            AIControl();

        if (Input.GetKey("c"))
            console.SetActive(true);

    }

    //detects console commands and applies the appropriate changes
    public void consoleCommands(Text inputText)
    {
        Renderer rend = background.GetComponent<Renderer>();

        if (inputText.text == "color -red")
        {
            rend.material.color = Color.red;
        }
        else if (inputText.text == "color -green")
        {
            rend.material.color = Color.green;
        }
        else if (inputText.text == "AI -easy")
        {
            AIErrorRange = 7;
            AISpeed = 5;
        }
        else if (inputText.text == "AI -medium")
        {
            AIErrorRange = 4;
            AISpeed = 10;
        }
        else if (inputText.text == "AI -hard")
        {
            AIErrorRange = 1;
            AISpeed = 20;
        }

    }

    private void manageMenu()
    {
        winText.text = mainMessage;
        p1ScoreText.text = player1Score.ToString();
        p2ScoreText.text = player2Score.ToString();
        
        if (menu.activeSelf && !console.activeSelf) {
            if (Input.GetButton("PongOption1"))
                startSinglePlayer();

            if (Input.GetButton("PongOption2"))
                startMultiplayerPlayer();
        }    
    }

    //initiates a singleplayer game
    public void startSinglePlayer()
    {
        Time.timeScale = 1.0f;
        player1Score = 0;
        player2Score = 0;
        mainMessage = "";
        multiplayer = false;
        menu.SetActive(false);
    }

    //initiates a multiplayer game
    public void startMultiplayerPlayer()
    {
        Time.timeScale = 1.0f;
        player1Score = 0;
        player2Score = 0;
        mainMessage = "";
        multiplayer = true;
        menu.SetActive(false);
    }

    //updates the score. detects if a player has won
    public void score()
    {
        if (ball.transform.position.x < player1.position.x)
        {
            player2Score += 1;
        }

        else if (ball.transform.position.x > player2.position.x)
        {
            player1Score += 1;
        }

        ball.transform.position = ballStartPosition;
        ball.zSpeed = Random.Range(-2, 2) * ball.zSpeedExtent;
        updateAIError();

        if(player1Score >= winScore)
        {
            mainMessage = "Player 1 won!";
            menu.SetActive(true);
            StartCoroutine(returnToMaze());
            //Time.timeScale = 0; 
        } else if(player2Score >= winScore)
        {
            mainMessage = "Player 2 won!";
            menu.SetActive(true);
            StartCoroutine(returnToMaze());
            //Time.timeScale = 0;        
        }
    }

    IEnumerator returnToMaze() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("scene__main");
    }

    //controls the AI player. For the single player mode
    private void AIControl()
    {
        Vector3 newPos = new Vector3(player2.position.x, player2.position.y, ball.transform.position.z + AIError);

        float step = AISpeed * Time.deltaTime;
        player2.position = Vector3.MoveTowards(player2.position, newPos, step);
    }

    //Updates the AIError variable, which determines if the AI will miss the ball, and by how much
    public void updateAIError()
    {
        AIError = Random.Range(AIErrorRange, -AIErrorRange);
    }

}
