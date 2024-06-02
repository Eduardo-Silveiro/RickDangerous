using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private static bool paused = false;
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject playerUICanvas; //para puder desligar a UI do player quando tiver saido da pausa
    [SerializeField] private GameObject optionsMenuPanel;
    [SerializeField] private GameObject controlsMenuPanel;


    void Start()
    {
        Time.timeScale = 1f;
        paused = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsMenuPanel.activeSelf)
            {
                OptionsBack();
            }
            else if (controlsMenuPanel.activeSelf) // check if the controls panel is active
            {
                ControlsBack();
            }
            else if (paused)
            {
                PlayGame();
            }
            else
            {
                StopGame();
            }

        }
    }

    /// <summary>
    /// Resumes the game by hiding the pause menu, restoring time scale, enabling Nomed UI, and resuming audio.
    /// </summary>
    public void PlayGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        playerUICanvas.SetActive(true);
        AudioListener.pause = false;


    }
    /// <summary>
    /// Pauses the game by displaying the pause menu, setting time scale to 0, disabling Nomed UI, and pausing audio.
    /// </summary>
    public void StopGame()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        playerUICanvas.SetActive(false);
        AudioListener.pause = true;

    }
    /// <summary>
    /// Displays the options menu by hiding the pause menu.
    /// </summary>
    public void Options()
    {
        pauseMenuPanel.SetActive(false);
        optionsMenuPanel.SetActive(true);

    }
    /// <summary>
    /// Returns from the options menu to the pause menu by hiding the options menu.
    /// </summary>
    public void OptionsBack()
    {
        pauseMenuPanel.SetActive(true);
        optionsMenuPanel.SetActive(false);
    }
    /// <summary>
    /// Displays the controls menu by hiding the pause menu.
    /// </summary>
    public void ControlsMenu()
    {
        pauseMenuPanel.SetActive(false);
        controlsMenuPanel.SetActive(true);

    }
    /// <summary>
    /// Returns from the controls menu to the pause menu by hiding the controls menu.
    /// </summary>
    public void ControlsBack()
    {
        pauseMenuPanel.SetActive(true);
        controlsMenuPanel.SetActive(false);
    }

    /// <summary>
    /// Loads the main menu scene.
    /// </summary>
    public void MainMenuComeBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
    /// <summary>
    /// Restarts the current scene by reloading it.
    /// </summary>
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        AudioListener.pause = false;
        paused = false;

    }
    /// <summary>
    /// Returns the paused state of the game.
    /// </summary>
    /// <returns>True if the game is paused, false otherwise.</returns>
    public bool IsPaused()
    {
        return paused;
    }
    /// <summary>
    /// Sets the paused state of the game.
    /// </summary>
    /// <param name="pauseds">The new paused state.</param>
    public void SetPaused(bool pauseds)
    {
        paused = pauseds;
    }
}
