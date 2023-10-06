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

        if (dirX > 0f)
        {
            
            if(dir != 'R')
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                dir = 'R';
            }
            animator.SetBool("IsRunning", true);
        }
        else if (dirX < 0f)
        {
            
            if(dir != 'L')
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
            animator.SetBool("IsJumping",true);
        }
        else if (rb.velocity.y < -.1f)
        {
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            animator.SetBool("IsCrouching", true);

        }
        else {
            animator.SetBool("IsCrouching", false);

        }

    }

    public bool IsGrounded(){
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
