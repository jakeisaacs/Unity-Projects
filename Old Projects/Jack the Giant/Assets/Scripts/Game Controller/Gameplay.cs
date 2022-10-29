using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    public static Gameplay instance;

    [SerializeField]
    private Text scoreText, coinText, lifeText, gameOverScore, gameOverCoins;

    [SerializeField]
    private GameObject pausePanel, gameOverPanel;

    [SerializeField]
    private GameObject readyButton, leftButton, rightButton;

    private void Awake()
    {
        MakeInstance();
    }

    private void Start()
    {
        Time.timeScale = 0f;
        leftButton.SetActive(false);
        rightButton.SetActive(false);
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    public void GameOver(int finalScore, int finalCoins)
    {
        gameOverPanel.SetActive(true);
        gameOverScore.text = "x" + finalScore.ToString();
        gameOverCoins.text = "x" + finalCoins.ToString();
        StartCoroutine(LoadMainMenu());
    }

    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(5f);
        SceneFader.instance.LoadLevel("Main Menu");
    }

    public void PlayerDiedRestart()
    {
        StartCoroutine(PlayerDied());
    }

    IEnumerator PlayerDied()
    {
        yield return new WaitForSeconds(1f);
        SceneFader.instance.LoadLevel("Gameplay");
    }

    public void SetScore(int score)
    {
        scoreText.text = "x" + score;
    }

    public void SetCoinScore(int coinScore)
    {
        coinText.text = "x" + coinScore;
    }

    public void SetLifeScore(int lifeScore)
    {
        lifeText.text = "x" + lifeScore;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
 //       GameManager.instance.gameStartedFromMain = true;
   //     GameManager.instance.gameStartedFromMain = false;
        Time.timeScale = 1f;
        //     SceneManager.LoadScene("Main Menu");
        SceneFader.instance.LoadLevel("Main Menu");
    }

    public void ReadyToStart()
    {
        Time.timeScale = 1;
        readyButton.SetActive(false);
        leftButton.SetActive(true);
        rightButton.SetActive(true);
    }


}
