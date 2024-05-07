using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pause game time
        pauseMenuUI.SetActive(true); // Activate pause menu UI
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume normal game time
        pauseMenuUI.SetActive(false); // Deactivate pause menu UI
    }
}
