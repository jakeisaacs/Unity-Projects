using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = true;
    private UIManager _uimanager;
    [SerializeField]
    private GameObject _player;

    void Start()
    {
        _uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();

    }

    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_player);
            gameOver = false;
            _uimanager.StartScreenOff();
        }

    }
}
