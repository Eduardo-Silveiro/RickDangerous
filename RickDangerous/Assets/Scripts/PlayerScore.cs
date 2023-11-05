using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore
{
	public string PlayerName { get; set; }
	public int Score { get; set; }

	public PlayerScore(string playerName, int score)
	{
		PlayerName = playerName;
		Score = score;
	}

	public string ToString()
	{
		return PlayerName + ", " + Score;
	}
}
