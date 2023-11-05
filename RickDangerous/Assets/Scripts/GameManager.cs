using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private List<PlayerScore> playerScoreList = new List<PlayerScore>();
	[SerializeField] private PlayerStatusSO playerData;

	public List<PlayerScore> getList() { return playerScoreList; }

	public void LoadAllPlayerScore()
	{
		for (int i = 0; i < playerScoreList.Count; i++)
		{
			string playerDataJson = PlayerPrefs.GetString("PlayerScore" + i, "");
			if (!string.IsNullOrEmpty(playerDataJson))
			{
				playerScoreList[i] = JsonUtility.FromJson<PlayerScore>(playerDataJson);
			}
		}
	}

	public void SaveAllPlayerScore()
	{
		for (int i = 0; i < playerScoreList.Count; i++)
		{
			string playerDataJson = JsonUtility.ToJson(playerScoreList[i]);
			PlayerPrefs.SetString("PlayerScore" + i, playerDataJson);
		}
		PlayerPrefs.Save();
	}

	public void UpdatePlayerScore(string username, int score)
	{
		PlayerScore player = playerScoreList.Find(p => p.PlayerName == username);
		if (player != null)
		{
			player.Score = score;
		}
		else
		{
			player = new PlayerScore(username,score);
			playerScoreList.Add(player);
		}

		foreach(PlayerScore ps in playerScoreList)
		{
			Debug.Log(ps.ToString());
		}

		SaveAllPlayerScore();
	}

	private void Awake()
	{
		LoadAllPlayerScore();
	}

	private void OnDestroy()
	{
		SaveAllPlayerScore();
	}

	public void AddPlayer(string name)
	{
		UpdatePlayerScore(name, playerData.Score);
	}

}
