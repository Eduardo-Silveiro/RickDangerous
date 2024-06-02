using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompletedScript : MonoBehaviour
{
    [SerializeField] private PlayerStatusSO playerData;
    [SerializeField] private TextMeshProUGUI scoresText;
    private ScoreManager scoreManager = new ScoreManager();
    private int score;

    private void Start()
    {
        scoresText.text = "Score: " + playerData.Score;
        score = playerData.Score;
        playerData.ResetAmmo();
        playerData.ResetHealth();
    }

    public void AddPlayer(GameObject gameObject)
    {
        string name = gameObject.GetComponent<Text>().text;

        //UpdatePlayerScore(name, playerData.Score);

        scoreManager.AddOrUpdateScore(name, score);

        MainMenu();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
