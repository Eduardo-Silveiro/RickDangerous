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