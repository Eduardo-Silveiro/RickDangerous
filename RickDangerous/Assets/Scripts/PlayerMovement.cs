using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] PlayerStatusSO playerStatus;
    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rb;
    private float dirX;

    [SerializeField] private LayerMask jumpableGround;

    private SpriteRenderer spriteRenderer;


    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");


        rb.velocity = new Vector2(dirX * playerStatus.Speed, rb.velocity.y);

       
        if (Input.GetButtonDown("Jump") && IsGrounded() == true)
        {


            rb.velocity = new Vector2(rb.velocity.x, playerStatus.JumpForce);
            //jumpSoundEffect.Play();
        }
       
        //fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);

        AnimationState();




    }

    public void AnimationState()
    {
        //MovementState state;

        if (dirX > 0f)
        {
            //state = MovementState.running;
            spriteRenderer.flipX = false;
        }
        else if (dirX < 0f)
        {
            //state = MovementState.running;
            spriteRenderer.flipX = true;
        }
        /**
        else
        {
            //state = MovementState.idle;
        }
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        animator.SetInteger("State", (int)state);
        **/
        }

    public bool IsGrounded(){
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
