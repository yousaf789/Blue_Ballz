using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    // public float acceleration = 0.6f;
    // public int maxSpeed = 10;
    public int playerIndex;

    public TextMeshProUGUI countText;
    //public GameObject winTextObject;
    //private GameObject tutorialTextObject;
    private Transform respawnPoint;
    private MenuController menuController;
    private ScoreHandler scoreHandler;
    private AudioSource pop;
    private AudioSource levelBackgroundSong;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private int player1Count;
    private int player2Count;
    // Start is called before the first frame update
    void Start()
    {
        // player1Count = 0;
        // player2Count = 0;
        Time.timeScale = 1;
        respawnPoint = GameObject.Find("RespawnPoint").transform;
        menuController = GameObject.Find("Canvas").GetComponent<MenuController>();
        scoreHandler = GameObject.Find("Canvas/CountPanel").GetComponent<ScoreHandler>();
        pop = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        //winTextObject.SetActive(false);
        //tutorialTextObject.SetActive(true);
    }

    void Update()
    {
        //Debug.Log("Yo");
        if(transform.position.y < -10)
        {
            Respawn();
        }
        // Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        // if (speed < maxSpeed){
        //     speed += acceleration * Time.deltaTime;
        // }
        // rb.AddForce(speed * movement);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        //countText.text = "Count: " + count.ToString() + "/12";
        menuController.AddCountText(playerIndex, count);
        //countText.text = "Count: " + scoreHandler.Score.ToString() + "/12";
        //tutorialTextObject.SetActive(false);
        if (scoreHandler.Score >= 21)
        {
            //winTextObject.SetActive(true);
            menuController.WinGame();
        }
    }

    void SetCountTextMultiplayer()
    {
        menuController.AddCountText(playerIndex, count);
        if (scoreHandler.Score >= 21)
        {
            if (player1Count > player2Count)
            {
                menuController.Player1Win();
            }
            else if (player1Count < player2Count)
            {
                menuController.Player2Win();
            }
            else
            {
                Debug.Log("Draw");
            }
        }
        else
        {
            if (playerIndex == 0)
            {
                player1Count += 1;
            }
            else if (playerIndex == 1)
            {
                player2Count += 1;
            }
        }
        // int p1Final += player1Count;
        // int p2Final += player2Count;
        Debug.Log("player 1 count:" + player1Count.ToString());
        Debug.Log("player 2 count:" + player2Count.ToString());
        // Debug.Log(p1Final);
        // Debug.Log(p2Final);
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            scoreHandler.Score += 1;
            pop.Play();

            //tutorialTextObject.SetActive(false);
            if (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4)
            {
                SetCountTextMultiplayer();
            }
            else
            {
                SetCountText();
            }        
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            //Respawn();
            EndGame();
        }
    }

    void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        transform.position = respawnPoint.position;
    }

    void EndGame()
    {
        menuController.LoseGame();
        gameObject.SetActive(false);

    }
}
