using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletCollector : MonoBehaviour
{
    [SerializeField] private BulletBoxesSO bulletBoxes;
    [SerializeField] private PlayerStatusSO playerData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerData.BulletCount += bulletBoxes.NumberOfAmmoGiven;

            Destroy(gameObject);
        }
    }

}
