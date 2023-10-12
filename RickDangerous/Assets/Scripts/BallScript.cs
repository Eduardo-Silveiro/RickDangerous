using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate the direction to the player only on the X-axis
            Vector3 direction = (player.position - transform.position);
            direction.y = 0; // Set vertical component to zero

            // Normalize the direction
            direction.Normalize();

            // Move the ball towards the player on the X-axis only
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
        }
    }
}
