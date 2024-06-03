using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{

    private Rigidbody2D rigidbody2D;
    private bool hasFallen = false;
    private BoxCollider2D boxCollider2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0;

        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = true;
    }

    //check if the stalactite hit the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasFallen)
        {
            rigidbody2D.gravityScale = 1;
            boxCollider2D.enabled = false;
            hasFallen = true;
            //disable the child object of the stalactite to avoid collision with the player after the stalactite has fallen on the player 
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}