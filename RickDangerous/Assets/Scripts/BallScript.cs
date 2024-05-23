using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform player;
    [SerializeField] private Transform invisibleWall;
    [SerializeField] private float range;
    private Rigidbody2D rb;
    private readonly float spinSpeed = 360.0f;
    private float distance;
    private Vector3 direction;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, invisibleWall.position);

        

        if (distance < range)
        {
            direction = (invisibleWall.position - transform.position);
            direction.y = 0;
        }
        else
        {
            direction = (player.position - transform.position);
            direction.y = 0;
        }

        direction.Normalize();

        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

        float spinDirection = Mathf.Sign(direction.x);
        float spinAngle = Time.time * spinSpeed * -spinDirection;
        transform.rotation = Quaternion.Euler(0, 0, spinAngle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InvisibleWall"))
        {
            Destroy(this.gameObject);
        }
    }
}
