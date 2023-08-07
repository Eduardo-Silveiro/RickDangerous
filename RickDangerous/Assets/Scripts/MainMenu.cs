using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject optionsMenuPanel;
    [SerializeField] private GameObject controlsMenuPanel;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject creditsMenuPanel;

    //private bool creditsMenuActive = false;


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Displays the controls menu by hiding the pause menu.
    /// </summary>
    public void ControlsMenu()
    {
        mainMenuPanel.SetActive(false);
        controlsMenuPanel.SetActive(true);
    }

    /// <summary>
    /// Returns from the controls menu to the pause menu by hiding the controls menu.
    /// </summary>
    public void ControlsBack()
    {
        controlsMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    /// <summary>
    /// Resumes the game by hiding the pause menu, restoring time scale, enabling Nomed UI, and resuming audio.
    /// </summary>
    public void Continue()
    {
        controlsMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        SceneManager.LoadScene("Level1");
    }

    /// <summary>
    /// Displays the options menu by hiding the pause menu.
    /// </summary>
    public void OptionsMenu()
    {
        mainMenuPanel.SetActive(false);
        optionsMenuPanel.SetActive(true);
    }

    /// <summary>
    /// Returns from the options menu to the pause menu by hiding the options menu.
    /// </summary>
    public void OptionsBack()
    {
        optionsMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    /// <summary>
    /// Loads Credits
    /// </summary>
    public void CreditsMenu()
    {
        mainMenuPanel.SetActive(false);
        creditsMenuPanel.SetActive(true);
        //creditsMenuActive = true;
        //delayTimer = 0f;
    }

    /// <summary>
    /// Execute the credtis with delay
    /// </summary>
    private void ExecuteAfterDelay()
    {
        mainMenuPanel.SetActive(true);
        creditsMenuPanel.SetActive(false);
    }
}
