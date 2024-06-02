using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
    [SerializeField] private Transform objectPosition;
    [SerializeField] private float distanceToStartsFalling;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private LayerMask groundLayer; // Adicionado para especificar a layer "Ground"

    private Rigidbody2D rigidbody2D;
    private Collider2D collider2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
        rigidbody2D.gravityScale = 0;
    }

    void Update()
    {
        if (Vector3.Distance(objectPosition.position, playerTransform.position) < distanceToStartsFalling)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);
            if (!hit.collider)
            {
                rigidbody2D.gravityScale = 1;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto colidido está na layer "Ground"
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            // Para a simulação do Rigidbody2D e desativa o Collider2D para evitar passar pelo chão
            rigidbody2D.simulated = false;
            collider2D.enabled = false;
        }
    }
}