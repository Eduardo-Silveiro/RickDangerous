using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartsSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject dart;
    [SerializeField] private float interval;
    private float timer;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        timer = interval;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (timer <= 0)
            {
                SpawnDart();
                timer = interval;
            }
            timer -= Time.deltaTime;
        }
    }

    void SpawnDart()
    {
        Instantiate(dart, transform.position, transform.rotation);
    }
}
