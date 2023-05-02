using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuController : MonoBehaviour
{
    public GameObject[] pauseUI; //index 0: button, index 1: panel
    public GameObject endPanel;
    public TextMeshProUGUI[] countText;
    public GameObject endPanelPlayer1Win;
    public GameObject endPanelPlayer2Win;

    //private PlayerController playerController;
    // Start is called before the first frame update
    private AudioSource gameOver;
    // private float gameOverVolume = 1f;
    private int player1Count;
    private int player2Count;
    void Start()
    {
        //pauseUI[1].SetActive(false);
        //playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameOver = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     //Debug.Log("Hi");
    //     gameOver.volume = gameOverVolume;
    // }

    // public void updateVolume(float volume)
    // {
    //     gameOverVolume = volume;
    // }

    public void LoseGame()
    {
        endPanel.SetActive(true);
        pauseUI[0].SetActive(false);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Game Over...";
        gameOver.Play();

    }

    public void WinGame()
    {
        endPanel.SetActive(true);
        pauseUI[0].SetActive(false);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You Win!!!";
    }

    public void Player1Win()
    {
        endPanelPlayer1Win.SetActive(true);
        pauseUI[0].SetActive(false);
        //endPanelPlayer1Win.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Player 1 Wins!!!";
    }

    public void Player2Win()
    {
        endPanelPlayer2Win.SetActive(true);
        pauseUI[0].SetActive(false);
        //endPanelPlayer2Win.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Player 2 Wins!!!";
    }

    public void AddCountText(int playerIndex, int count)
    {
        countText[playerIndex].text = "Count: " + count.ToString();
    }

    public void TransitionScene(int level)
    {
        //var lastSceneIndex = SceneManager.sceneCount - 1;
        //var lastLoadedScene = SceneManager.GetSceneAt(lastSceneIndex);
        //SceneManager.UnloadSceneAsync(lastLoadedScene);
        StartCoroutine(LoadLevel(level));
 
        //StartCoroutine(LoadLevel(level));
    }

    IEnumerator LoadLevel(int level)
    {
        SceneManager.LoadSceneAsync(level);
        yield return null;
        //SceneManager.LoadScene(level);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseUI[0].SetActive(false);
        pauseUI[1].SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        pauseUI[0].SetActive(true);
        pauseUI[1].SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}

