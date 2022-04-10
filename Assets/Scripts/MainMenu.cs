using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string leveltoLoad = "MainLevel";
    public void Play()
    {
        SceneManager.LoadScene(leveltoLoad);
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
