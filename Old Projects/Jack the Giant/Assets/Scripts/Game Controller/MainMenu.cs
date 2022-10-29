using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button musicButton;

    [SerializeField]
    private Sprite[] musicIcons;

    // Start is called before the first frame update
    void Start()
    {
        CheckToPlayMusic();
    }

    void CheckToPlayMusic()
    {
        if (GamePreferences.GetMusicState() == 1)
        {
            MusicManager.instance.PlayMusic(true);
            musicButton.image.sprite = musicIcons[0];
        }
        else
        {
            MusicManager.instance.PlayMusic(false);
            musicButton.image.sprite = musicIcons[1];
        }
    }

    public void StartGame()
    {
   //     Application.LoadLevel("Gameplay");
        SceneFader.instance.LoadLevel("Gameplay");
    }

    public void HighScoreMenu()
    {
        SceneFader.instance.LoadLevel("High Score");
    }

    public void OptionsMenu()
    {
        SceneFader.instance.LoadLevel("Options Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MusicButton()
    {
        if(GamePreferences.GetMusicState() == 0)
        {
            GamePreferences.SetMusicState(1);
            MusicManager.instance.PlayMusic(true);
            musicButton.image.sprite = musicIcons[0];
        }
        else if (GamePreferences.GetMusicState() == 1)
        {
            GamePreferences.SetMusicState(0);
            MusicManager.instance.PlayMusic(false);
            musicButton.image.sprite = musicIcons[1];
        }
    }

}
