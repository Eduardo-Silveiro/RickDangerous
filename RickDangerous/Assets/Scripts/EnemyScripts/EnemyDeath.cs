using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private PlayerStatusSO playerStatus;
    [SerializeField] private Animator animator;
    private EnemyPatrol enemyPatrol;

    private void Start()
    {
        enemyPatrol = GetComponent<EnemyPatrol>();

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerStatus.MaxHealth -= 100;
        }
    }

    public void Death()
    {
        animator.SetTrigger("death");
        float deathAnimationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        enemyPatrol.SetSpeed();
        Invoke(nameof(DestroyEnemy), deathAnimationLength);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
