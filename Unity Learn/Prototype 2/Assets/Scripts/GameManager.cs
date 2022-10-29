using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int playerLives;
    private int playerScore;

    void Awake()
    {
        playerLives = 3;
        playerScore = 0;
    }

    public void decreasePlayerLives()
    {
        playerLives--;
        Debug.Log("Player Lives: " + playerLives);

        if (playerLives == 0)
        {
            Debug.Log("Game Over!");
        }
    }

    public void increasePlayerScore(int amount)
    {
        playerScore += amount;
        Debug.Log("Player Score: " + playerScore);
    }
}
