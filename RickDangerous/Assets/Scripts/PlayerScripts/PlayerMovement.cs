using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerStatusSO playerStatus;
    private BoxCollider2D boxCollider2D;
    private Vector2 originalColliderSize;
    private Vector2 crouchingColliderSize;
    private Vector2 originalColliderOffset;
    private Vector2 crouchingColliderOffset;
    private Rigidbody2D rb;
    private float dirX;
    private char dir;

    [SerializeField] private LayerMask jumpableGround;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        dir = 'R';

        // Store the original size and offset of the collider
        originalColliderSize = boxCollider2D.size;
        originalColliderOffset = boxCollider2D.offset;

        // Define the size and offset for the crouching state
        crouchingColliderSize = new Vector2(originalColliderSize.x, originalColliderSize.y / 2);
        crouchingColliderOffset = new Vector2(originalColliderOffset.x, originalColliderOffset.y / 2);
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * playerStatus.Speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded() == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, playerStatus.JumpForce);
        }

        AnimationState();
    }

    public void AnimationState()
    {
        if (dirX > 0f)
        {
            if (dir != 'R')
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                dir = 'R';
            }
            animator.SetBool("IsRunning", true);
        }
        else if (dirX < 0f)
        {
            if (dir != 'L')
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                dir = 'L';
            }
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        if (rb.velocity.y > .1f)
        {
            animator.SetBool("IsJumping", true);
        }
        else if (rb.velocity.y < -.1f)
        {
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            animator.SetBool("IsCrouching", true);
            AdjustColliderForCrouch(true);
        }
        else
        {
            animator.SetBool("IsCrouching", false);
            AdjustColliderForCrouch(false);
        }
    }

    private void AdjustColliderForCrouch(bool isCrouching)
    {
        if (isCrouching)
        {
            boxCollider2D.size = crouchingColliderSize;
            boxCollider2D.offset = crouchingColliderOffset;
        }
        else
        {
            boxCollider2D.size = originalColliderSize;
            boxCollider2D.offset = originalColliderOffset;
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
