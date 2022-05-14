using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool gameIsOver;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    void Start()
    {
        gameIsOver = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameIsOver)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        gameIsOver = true;
        FindObjectOfType<AudioManager>().Play("YouLose");
        gameOverUI.SetActive(true);
    }
    public void WinLevel()
    {
        gameIsOver = true;
        FindObjectOfType<AudioManager>().Play("YouWin");
        completeLevelUI.SetActive(true);
    }
}
