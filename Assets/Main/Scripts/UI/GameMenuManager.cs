using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    public GameObject directions;
    public GameObject pauseMenu;

    public bool isPaused;

    void Start()
    {
        ShowDirections();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ManagePause();
        }
    }

    public void ManagePause()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void ShowDirections()
    {
        Time.timeScale = 0.0f;
        directions.SetActive(true);
    }

    public void CloseDirections()
    {
        Time.timeScale = 1.0f;
        directions.SetActive(false);
        pauseMenu.SetActive(false);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void SaveGame()
    {
        // To Implement
    }
}
