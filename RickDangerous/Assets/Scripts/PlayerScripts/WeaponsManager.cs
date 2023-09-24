using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    [SerializeField] private Transform shootingPos;
    [SerializeField] private Transform bombPos;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bomb;
    [SerializeField] private float bulletInterval;
    [SerializeField] private float bombInterval;

    private float bulletCooldownTimer;
    private float bombCooldownTimer;

    private void Start()
    {
        bulletCooldownTimer = 0f;
        bombCooldownTimer = 0f;
    }

    void Update()
    {
        if (bulletCooldownTimer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                SpawnBullet();
                bulletCooldownTimer = bulletInterval;
            }
        }
        else
        {
            // Reduce the cooldown timer
            bulletCooldownTimer -= Time.deltaTime;
        }

        if (bombCooldownTimer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                SpawnBomb();
                bombCooldownTimer = bombInterval;
            }
        }
        else
        {
            // Reduce the cooldown timer
            bombCooldownTimer -= Time.deltaTime;
        }
    }

    void SpawnBullet()
    {
        Instantiate(bullet, shootingPos.position, transform.rotation);
    }

    void SpawnBomb()
    {
        Instantiate(bomb, bombPos.position, Quaternion.identity);
    }
}
