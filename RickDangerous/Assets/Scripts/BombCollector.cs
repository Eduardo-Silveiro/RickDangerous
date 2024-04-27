using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BombCollector : MonoBehaviour
{
    [SerializeField] private BombBoxesSO bombBoxes;
    [SerializeField] private PlayerStatusSO playerData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerData.BombCount += bombBoxes.NumberOfBombsGiven;
            Destroy(gameObject);
        }
    }
}
