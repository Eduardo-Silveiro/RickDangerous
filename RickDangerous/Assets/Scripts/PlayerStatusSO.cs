using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatus", menuName = "Player Status")]

public class PlayerStatusSO : ScriptableObject
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    public float MaxHealth { 
        get { return maxHealth; }
        set { maxHealth = value; }
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

}
