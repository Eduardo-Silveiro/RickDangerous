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
    [SerializeField] private AudioSource explosiveSoundSource; // Apenas AudioSource

    private float bulletCooldownTimer;
    private float bombCooldownTimer;

    private void Start()
    {
        bulletCooldownTimer = 0f;
        bombCooldownTimer = 0f;
        if (explosiveSoundSource == null)
        {
            Debug.LogError("Explosive sound source is not assigned in the inspector");
        }
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
        if (bullet == null)
        {
            Debug.LogError("Bullet prefab is not assigned in the inspector");
            return;
        }

        if(playerData.BulletCount > 0)
        {
            Instantiate(bullet, shootingPos.position, transform.rotation);
            playerData.BulletCount--;
            explosiveSound.Play();

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
            StartCoroutine(PlayExplosionSoundAfterDelay());
        }
    }

    private IEnumerator PlayExplosionSoundAfterDelay()
    {
        float explosionAnimationDuration = 3.5f; 
        float delay = explosionAnimationDuration; 
        if (delay > 0)
        {
            yield return new WaitForSeconds(delay);
        }
        explosiveSoundSource.Play();
        yield return new WaitForSeconds(1.2f); 
        explosiveSoundSource.Stop();
    }
}
