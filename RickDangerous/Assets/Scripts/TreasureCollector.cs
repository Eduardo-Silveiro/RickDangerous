using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TreasureCollector : MonoBehaviour
{

    [SerializeField] private TMP_Text treasureText;
    [SerializeField] private TreasuresSO treasures;
    private static int value = 0;

    private void Start()
    {
        UpdateTreasureText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            value += treasures.TreasureValue;
            UpdateTreasureText();
            Destroy(gameObject);
        }
    }

    private void UpdateTreasureText()
    {
        treasureText.text = value.ToString("D6");
    }

    
}