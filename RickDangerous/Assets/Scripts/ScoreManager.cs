using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public void SaveScores(ScoreData data)
    {
        string filePath = Path.Combine(Application.persistentDataPath, "scores.json");

        for (int i = 0; i < data.scores.Count; i++)
        {
            Debug.Log(data.scores[i].ToString());
        }

        string json = JsonUtility.ToJson(data); 

        Debug.Log(json);
        File.WriteAllText(filePath, json);
    }

    public ScoreData LoadScores()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "scores.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            if(json == null || json == "")
            {
                return new ScoreData { scores = new List<PlayerScore>() };
            }
            return JsonUtility.FromJson<ScoreData>(json);
        }
        
        return new ScoreData { scores = new List<PlayerScore>() };
    }

    public void AddOrUpdateScore(string playerName, int score)
    {
        ScoreData data = LoadScores();

        PlayerScore existingPlayer = data.scores.Find(p => p.playerName == playerName);

        if (existingPlayer != null)
        {
            existingPlayer.score = Math.Max(existingPlayer.score, score);
        }
        else
        {
            data.scores.Add(new PlayerScore(playerName, score));
        }

        SaveScores(data);
    }

    public string DisplayScores()
    {
        ScoreData data = LoadScores();
        string scoreString = "";

        if(data.scores.Count == 0)
        {
            return "No scores yet!";
        }

        // Loop through each score and format it
        foreach (PlayerScore score in data.scores)
        {
            // Formats the score as a 6-digit number with leading zeros
            string formattedScore = score.score.ToString("D6");
            // Create the formatted score line with dots and player's name
            string scoreLine = $"{formattedScore} .......... {score.playerName}\n";
            // Append the formatted score line to the overall score string
            scoreString += scoreLine;
        }

        return scoreString;
    }

}
