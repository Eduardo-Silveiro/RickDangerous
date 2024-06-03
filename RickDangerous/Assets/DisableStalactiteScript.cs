using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableStalactiteScript : MonoBehaviour
{
    private GameObject playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = transform.parent.Find("Player Collider").gameObject;

        playerCollider.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.Com)
        {
            //disable the object thats at the same level as this object in the hierarchy to avoid collision with the player after the stalactite has fallen on the player
            transform.GetChild(1).gameObject.SetActive(false);

        }*/

        //check if the stalectite cllided with the Ground Layer and disable the object thats at the same level as this object in the hierarchy to avoid collision with the player after the stalactite has fallen on the player
        if (collision.gameObject.layer == 3)
        {
            Debug.Log("Collided with Ground");

            playerCollider.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        playerCollider.SetActive(true);
    }
}
