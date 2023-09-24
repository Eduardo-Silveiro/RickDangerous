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

    public int Score {
        get { return score; }
        set { score = value; }
    }
    public void ResetScore()
    {
        score = 0;
    }

}
