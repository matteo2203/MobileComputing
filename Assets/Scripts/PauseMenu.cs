using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject InterfaceUI;
    public GameObject main;
    public GameObject settings;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
        InterfaceUI.SetActive(true);
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        InterfaceUI.SetActive(false);
    }
    public void Settings()
    {
        main.SetActive(false);
        settings.SetActive(true);
    }
    public void Main()
    {
        main.SetActive(true);
        settings.SetActive(false);
    }
    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
}
