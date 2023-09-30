using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
    [SerializeField] private Transform objectPosition;
    [SerializeField] private float distanceToStartsFalling;
    [SerializeField] private Transform playerTransform;


    private Rigidbody2D rigidbody2D;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(objectPosition.position, playerTransform.position) <distanceToStartsFalling){
            rigidbody2D.gravityScale = 1;
            
        
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // You can check the object it collided with using collision.gameObject or collision.tag

        // For now, let's deactivate the Rigidbody2D when it collides with any object
        rigidbody2D.simulated = false;
    }
}
