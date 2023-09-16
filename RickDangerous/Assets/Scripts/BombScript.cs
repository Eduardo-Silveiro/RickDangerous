using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField] private float explosionDelay;
    private BoxCollider2D boxCollider;
    private bool hasExploded = false;


    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        Invoke("Explode", explosionDelay);
    }

    private void Explode()
    {
        if (hasExploded) return; // Ensure the bomb only explodes once
        hasExploded = true;

        Vector2 center = boxCollider.bounds.center;
        Vector2 size = boxCollider.size;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(center, size, 0f);

        foreach (Collider2D col in colliders)
        {
            // Check if the object has the specified tag
            if (col.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Destruir Enemy");
                Destroy(col.gameObject);
            }

            if (col.gameObject.CompareTag("Player"))
            {
                Debug.Log("Destruir Player");
                //Destroy(col.gameObject);
            }
        }

        Destroy(this.gameObject);
    }
}
