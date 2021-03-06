using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string leveltoLoad = "LevelSelect";

    public SceneFader sceneFader;

    public void Start()
    {
        FindObjectOfType<AudioManager>().Play("MainMenuMusic");
    }
    public void Play()
    {
        sceneFader.FadeTo(leveltoLoad);
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
