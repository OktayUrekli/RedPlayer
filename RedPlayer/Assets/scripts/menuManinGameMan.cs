using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManinGameMan : MonoBehaviour
{
    public GameObject inGameScreen, pauseScreen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pauseButton()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }

    public void playButton()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        inGameScreen.SetActive(true);
    }

    public void rePlayButton()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(1);
    }

    public void homeButton()
    {
        Time.timeScale = 1;
        DataManager.instance.SaveData();
        SceneManager.LoadScene(0);
    }
}
