using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TreasureCollector : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TreasuresSO treasures;
    [SerializeField] private PlayerStatusSO playerStats;     
    private int value = 0;

    private void Start()
    {
        //check if scoreText is assigned in the inspector, if not search for it in the scene with the tag "ScoreText" 
        if (scoreText == null)
        {
            scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TMP_Text>();
        }

        playerStats.ResetScore();
        //UpdateTreasureText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            playerStats.Score += treasures.TreasureValue; 
            UpdateTreasureText();
            Destroy(gameObject);
        }
    }

    private void UpdateTreasureText()
    {
        scoreText.text = playerStats.Score.ToString("D6");
    }

    
}