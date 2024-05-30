using System.Collections;
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
    [SerializeField] private AudioSource playerSteps;

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
        crouchingColliderSize = new Vector2(originalColliderSize.x, originalColliderSize.y / 1.8f);
        crouchingColliderOffset = new Vector2(originalColliderOffset.x, originalColliderOffset.y / 1.8f);
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * playerStatus.Speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded() && !animator.GetBool("IsCrouching"))
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
            if (!playerSteps.isPlaying)
            {
                playerSteps.Play();
            }
        }
        else if (dirX < 0f)
        {
            if (dir != 'L')
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                dir = 'L';
            }
            animator.SetBool("IsRunning", true);
            if (!playerSteps.isPlaying)
            {
                playerSteps.Play();
            }
        }
        else
        {
            animator.SetBool("IsRunning", false);
            if (playerSteps.isPlaying)
            {
                playerSteps.Stop();
            }
        }

        if (rb.velocity.y > .1f)
        {
            animator.SetBool("IsJumping", true);
        }
        else if (rb.velocity.y < -.1f)
        {
            animator.SetBool("IsJumping", false);
        }

        // Immediately cancel running if shift is pressed and initiate crouching
        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            animator.SetBool("IsRunning", false);
            if (playerSteps.isPlaying)
            {
                playerSteps.Stop();
            }
            // Initiate crouching immediately
            if (!animator.GetBool("IsCrouching"))
            {
                StartCoroutine(StartCrouching());
            }
            animator.SetBool("IsCrouching", true);
        }
        else
        {
            if (animator.GetBool("IsCrouching"))
            {
                StartCoroutine(StopCrouching());
            }
            animator.SetBool("IsCrouching", false);
        }
    }

    private IEnumerator StartCrouching()
    {
        // Adjust position to ensure the collider stays above ground
        transform.position = new Vector3(transform.position.x, transform.position.y - (originalColliderSize.y - crouchingColliderSize.y) / 2, transform.position.z);
        yield return StartCoroutine(LerpColliderSize(originalColliderSize, crouchingColliderSize, originalColliderOffset, crouchingColliderOffset, 0.2f));
    }

    private IEnumerator StopCrouching()
    {
        yield return StartCoroutine(LerpColliderSize(crouchingColliderSize, originalColliderSize, crouchingColliderOffset, originalColliderOffset, 0.2f));
        transform.position = new Vector3(transform.position.x, transform.position.y + (originalColliderSize.y - crouchingColliderSize.y) / 2, transform.position.z);
        animator.SetBool("IsCrouching", false);
    }

    private IEnumerator LerpColliderSize(Vector2 startSize, Vector2 endSize, Vector2 startOffset, Vector2 endOffset, float duration)
    {
        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            boxCollider2D.size = Vector2.Lerp(startSize, endSize, time / duration);
            boxCollider2D.offset = Vector2.Lerp(startOffset, endOffset, time / duration);
            yield return null;
        }
        boxCollider2D.size = endSize;
        boxCollider2D.offset = endOffset;
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
