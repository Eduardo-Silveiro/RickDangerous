using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BombCollector : MonoBehaviour
{
    [SerializeField] private TMP_Text bombText;
    [SerializeField] private BombBoxesSO bombBoxes;
    private static int value = 0;
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            value += bombBoxes.NumberOfBombsGiven;
            UpdateAmmoText();
            Destroy(gameObject);
        }
    }

    private void UpdateAmmoText()
    {
        bombText.text = "x" + value.ToString();
    }
}
