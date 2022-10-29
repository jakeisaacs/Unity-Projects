using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public bool gameStartedFromMain, gameRestarted;

    [HideInInspector]
    public int score, coinScore, lifeScore;

    // Start is called before the first frame update
    void Awake()
    {
        MakeSingleton();
    }

    private void Start()
    {
        InitializeVariable();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneWasLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneWasLoaded;
    }

    private void OnSceneWasLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Gameplay")
        {
            if (gameRestarted)
            {
                Gameplay.instance.SetScore(score);
                Gameplay.instance.SetCoinScore(coinScore);
                Gameplay.instance.SetLifeScore(lifeScore);

                PlayerScore.scoreCount = score;
                PlayerScore.coinCount = coinScore;
                PlayerScore.lifeCount = lifeScore;
            }
            else if (gameStartedFromMain)
            {
                PlayerScore.scoreCount = 0;
                PlayerScore.coinCount = 0;
                PlayerScore.lifeCount = 3;

                Gameplay.instance.SetScore(0);
                Gameplay.instance.SetCoinScore(0);
                Gameplay.instance.SetLifeScore(3);
                gameStartedFromMain = false;
            }
        }
        
    }

    void InitializeVariable()
    {
        if(!PlayerPrefs.HasKey("Game Initialized"))
        {
            GamePreferences.SetEasyDifficulty(0);
            GamePreferences.SetMediumDifficulty(1);
            GamePreferences.SetHardDifficulty(0);

            GamePreferences.SetEasyDifficultyHighScore(0);
            GamePreferences.SetMediumDifficultyHighScore(0);
            GamePreferences.SetHardDifficultyHighScore(0);

            GamePreferences.SetEasyDifficultyCoinScore(0);
            GamePreferences.SetMediumDifficultyCoinScore(0);
            GamePreferences.SetHardDifficultyCoinScore(0);

            GamePreferences.SetMusicState(0);

            PlayerPrefs.SetInt("Game Initialized", 0);
        }
    }

    void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CheckGameStatus(int score, int coinScore, int lifeScore)
    {
        if(lifeScore <= 0)
        {
            if(GamePreferences.GetEasyDifficulty() == 1)
            {
                int highscore = GamePreferences.GetEasyDifficultyHighScore();
                int coin = GamePreferences.GetEasyDifficultyCoinScore();

                if(highscore < score)
                     GamePreferences.SetEasyDifficultyHighScore(score);


                if (coin < coinScore)
                    GamePreferences.SetEasyDifficultyCoinScore(coinScore);

            }
            else if (GamePreferences.GetMediumDifficulty() == 1)
            {
                int highscore = GamePreferences.GetMediumDifficultyHighScore();
                int coin = GamePreferences.GetMediumDifficultyCoinScore();

                if (highscore < score)
                    GamePreferences.SetMediumDifficultyHighScore(score);


                if (coin < coinScore)
                    GamePreferences.SetMediumDifficultyCoinScore(coinScore);

            }
            else if (GamePreferences.GetHardDifficulty() == 1)
            {
                int highscore = GamePreferences.GetHardDifficultyHighScore();
                int coin = GamePreferences.GetHardDifficultyCoinScore();

                if (highscore < score)
                    GamePreferences.SetHardDifficultyHighScore(score);


                if (coin < coinScore)
                    GamePreferences.SetHardDifficultyCoinScore(coinScore);

            }

            gameRestarted = false;
            gameStartedFromMain = true;

            PlayerScore.scoreCount = 0;
            PlayerScore.coinCount = 0;
            PlayerScore.lifeCount = 3;

            Gameplay.instance.GameOver(score, coinScore);
        }
        else
        {
            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;

            gameRestarted = true;
            gameStartedFromMain = false;

            Gameplay.instance.PlayerDiedRestart();
        }
    }
}
