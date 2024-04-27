using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUiScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI bombText;
    [SerializeField] private TextMeshProUGUI bulletText;
    [SerializeField] private PlayerStatusSO playerData;

    void Start()
    {
        UpdateUi();
    }

    void Update()
    {
        UpdateUi();
    }

    public void UpdateUi()
    {
        scoreText.text = playerData.Score.ToString("000000");
        healthText.text = "x" + playerData.CurrentHealth;
        bombText.text = "x" + playerData.BombCount;
        bulletText.text = "x" + playerData.BulletCount;
    }
}
