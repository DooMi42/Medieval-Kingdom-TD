using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;
    public void Restart()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        FindObjectOfType<AudioManager>().StopPlay("GameMusic");
    }
    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
        FindObjectOfType<AudioManager>().StopPlay("GameMusic");
    }
}
