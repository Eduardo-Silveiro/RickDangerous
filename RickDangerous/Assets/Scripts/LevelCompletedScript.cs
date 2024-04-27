using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelCompletedScript : MonoBehaviour
{
    [SerializeField] private PlayerStatusSO playerData;
    [SerializeField] private TextMeshProUGUI scoresText;

    private void Start()
    {
        scoresText.text = "Score: " + playerData.Score;
        playerData.ResetAmmo();
        playerData.ResetHealth();
    }
}
