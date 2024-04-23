using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerScore
{
    public string playerName;
    public int score;

    public PlayerScore(string playerName, int score)
	{
        this.playerName = playerName;
        this.score = score;
	}

	public string ToString()
	{
		return playerName + ", " + score;
	}
}

[System.Serializable]
public class ScoreData
{
    public List<PlayerScore> scores = new List<PlayerScore>();
}
