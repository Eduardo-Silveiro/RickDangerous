using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	[SerializeField] private PlayerStatusSO playerData;
	private ScoreManager scoreManager = new ScoreManager();

    private void Start()
    {
        playerData.ResetAmmo();
        playerData.ResetScore();
    }

    public void AddPlayer(GameObject gameObject)
	{
		string name = gameObject.GetComponent<Text>().text;

		//UpdatePlayerScore(name, playerData.Score);

        scoreManager.AddOrUpdateScore(name, playerData.Score);

		MainMenu();
    }

	public void MainMenu()
	{
        SceneManager.LoadScene("MainMenu");
    }

	public void GameOver()
	{
        SceneManager.LoadScene("GameOver");
    }
}
