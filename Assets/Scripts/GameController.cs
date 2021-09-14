using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;
    public static GameController instance;
    public GameObject gameOver;
    public GameObject gamePause;
        

    // Start is called before the first frame update
    void Start()
    {
        instance = this;    
    }

    public void UpdateScoreText() 
    {
        scoreText.text = totalScore.ToString();
    }

    public void ShowGameOver() 
    {
        gameOver.SetActive(true);
    }

    

    public void RestartGame() 
    {
        SceneManager.LoadScene("Level01", LoadSceneMode.Single);
    }

    public void GamePause() 
    {
        Time.timeScale = 0;
        gamePause.SetActive(true);
    }

    public void Return()
    {
        Time.timeScale = 1;
        gamePause.SetActive(false);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

 }
