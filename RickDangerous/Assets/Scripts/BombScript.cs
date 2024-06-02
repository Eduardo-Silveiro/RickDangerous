using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BombScript : MonoBehaviour
{
    [SerializeField] private float explosionDelay;
    private BoxCollider2D boxCollider;
    private bool hasExploded = false;
    private Animator animator;
    [SerializeField] PlayerLife player;
    private bool hitPlayer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        Invoke("Explode", explosionDelay);
        hitPlayer = false;
    }

    private void Update()
    {

        if (hitPlayer && animator.GetCurrentAnimatorStateInfo(0).IsName("Explosion") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3f )
        {
            hitPlayer = false;
            player.TakeDamage();
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Explosion") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
        {
            Destroy(this.gameObject);
        }
    }

    private void Explode()
    {
        if (hasExploded) return; // Ensure the bomb only explodes once
        hasExploded = true;

        animator.SetTrigger("Explosion");

        Vector2 center = boxCollider.bounds.center;
        Vector2 size = boxCollider.size;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(center, size, 0f);

        foreach (Collider2D col in colliders)
        {
            // Check if the object has the specified tag
            if (col.gameObject.CompareTag("Enemy"))
            {
                /*Debug.Log("Destruir Enemy");
                Destroy(col.gameObject);*/
                col.gameObject.GetComponent<EnemyDeath>().Death();
            }

            if (col.gameObject.CompareTag("Player"))
            {
                Debug.Log("Destruir Player");
                hitPlayer = true;
            }
        }
    }
}
