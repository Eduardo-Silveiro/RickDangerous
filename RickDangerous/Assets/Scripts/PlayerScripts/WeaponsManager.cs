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
    [SerializeField] private PlayerStatusSO playerData;
    [SerializeField] private AudioSource explosiveSound;
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
                explosiveSound.Play();

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
        if (bullet == null)
        {
            Debug.LogError("Bullet prefab is not assigned in the inspector");
            return;
        }

        if(playerData.BulletCount > 0)
        {
            Instantiate(bullet, shootingPos.position, transform.rotation);
            playerData.BulletCount--;
        }
        
    }

    void SpawnBomb()
    {
        if (bomb == null)
        {
            Debug.LogError("Bomb prefab is not assigned in the inspector");
            return;
        }

        if(playerData.BombCount > 0)
        {
            Instantiate(bomb, bombPos.position, Quaternion.identity);
            playerData.BombCount--;
        }
    }
}
