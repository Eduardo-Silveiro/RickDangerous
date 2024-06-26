using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private PlayerStatusSO playerStatus;

    // Static variables
    private static bool gameStarted = false;
    private static float health;

    [SerializeField] private TMP_Text healthText;



    private void Start()
    {
        animator = GetComponent<Animator>();

        if (!gameStarted)
        {
            health = playerStatus.MaxHealth;
            gameStarted = true;
        }

        //playerStatus.CurrentHealth = health;
        UpdateHealthText();
    }


    /// <summary>
    /// Update the static health variable when the player object is destroyed
    /// This way, the updated health will persist even after a scene reload
    /// </summary>
    private void OnDestroy()
    {
        health = playerStatus.CurrentHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Stalactite") || collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Stalactite") || collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player hit by " + collision.gameObject.tag);
            TakeDamage();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void TakeDamage()
    {
        playerStatus.TakeDamage();
        UpdateHealthText();

        if (playerStatus.CurrentHealth <= 0)
        {
            Debug.Log("Player died " + playerStatus.Score);
            Die();
        }
        else
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void UpdateHealthText()
    {
        //healthText.text = "x" + playerStatus.CurrentHealth.ToString();
    }
}


/** Se formos usar detetor de queda quando o gajo sair fora do mapa ou cair num buraco
private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("FallDetector") == true)
    {
        Die();
    }

}
**/