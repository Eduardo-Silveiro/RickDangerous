using UnityEngine;
using TMPro;

public class TreasureCollector : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TreasuresSO treasures;
    [SerializeField] private PlayerStatusSO playerStats;
    private AudioSource audioSource;

    private void Start()
    {
        playerStats.ResetScore();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Log to verify that the AudioSource was added successfully
        if (audioSource != null)
        {
            Debug.Log("AudioSource added successfully.");
        }
        else
        {
            Debug.LogError("Failed to add AudioSource.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerStats.Score += treasures.TreasureValue;
            PlayTreasureSound();
            UpdateTreasureText();
            Destroy(gameObject);
        }
    }

    private void PlayTreasureSound()
    {
        if (treasures.TreasureClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(treasures.TreasureClip);
            Debug.Log("Playing treasure sound.");
        }
        else
        {
            Debug.LogError("Failed to play treasure sound. Either treasureClip or audioSource is null.");
        }
    }

    private void UpdateTreasureText()
    {
        scoreText.text = playerStats.Score.ToString("D6");
    }
}
