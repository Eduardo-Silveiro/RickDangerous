using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletCollector : MonoBehaviour
{
    [SerializeField] private TMP_Text bulletText;
    [SerializeField] private BulletBoxesSO bulletBoxes;
    private static int value = 0;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            value += bulletBoxes.NumberOfAmmoGiven;
            UpdateAmmoText();
            Destroy(gameObject);
        }
    }

    private void UpdateAmmoText()
    {
        bulletText.text = "x" +value.ToString();
    }

}
