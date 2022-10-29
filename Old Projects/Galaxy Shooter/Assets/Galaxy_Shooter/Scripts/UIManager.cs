using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image livesImage;
    public Text scoreText;
    public Image startScreen;
    public int score = 0;
    private GameManager gameManager;
    private SpawnManager spawnManager;

    void Start()
    {
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void UpdateLives(int currentLives)
    {
        livesImage.sprite = lives[currentLives];
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }

    public void StartScreenOff()
    {
        startScreen.enabled = false;
        score = 0;
        scoreText.text = "Score: " + score;
        spawnManager.StartSpawn();
    }

    public void StartScreenOn()
    {
        gameManager.gameOver = true;
        startScreen.enabled = true;
        spawnManager.StopSpawn();
    }
}
