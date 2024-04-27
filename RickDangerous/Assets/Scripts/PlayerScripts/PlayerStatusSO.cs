using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatus", menuName = "Player Status")]

public class PlayerStatusSO : ScriptableObject
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] int score;
    [SerializeField] private int bombCount;
    [SerializeField] private int bulletCount;

    public float MaxHealth { 
        get { return maxHealth; }
        set { maxHealth = value; }
    }
    public float CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public float JumpForce {
        get { return jumpForce; }
        set { jumpForce = value; }

    }

    public int BombCount
    {
        get { return bombCount; }
        set { bombCount = value; }
    }

    public int BulletCount
    {
        get { return bulletCount; }
        set { bulletCount = value; }
    }

    public int Score {
        get { return score; }
        set { score = value; }
    }
    public void ResetScore()
    {
        score = 0;
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public void ResetBulletCount()
    {
        bulletCount = 5;
    }

    public void ResetBombCount()
    {
        bombCount = 5;
    }

    public void ResetAmmo()
    {
        ResetBulletCount();
        ResetBombCount();
    }

}
