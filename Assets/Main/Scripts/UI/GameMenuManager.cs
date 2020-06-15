using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    public GameObject directions;
    public GameObject pauseMenu;
    public GameObject inventoryMenu;
    public GameObject DigUpPanel;

    public bool isPaused;

    void Start()
    {
        ShowDirections();
        CloseInventory();
        CloseDigPanel();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ManagePause();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenInventory();
        }
    }

    public void ManagePause()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
            CloseInventory();
        }
        else
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void OpenInventory()
    {
        inventoryMenu.SetActive(true);
        inventoryMenu.GetComponent<InventoryUI>().UpdateAllSquares();
        isPaused = true;
        Time.timeScale = 0.0f;
    }

    public void CloseInventory()
    {
        inventoryMenu.SetActive(false);
    }

    public void CloseDigPanel()
    {
        DigUpPanel.SetActive(false);
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
