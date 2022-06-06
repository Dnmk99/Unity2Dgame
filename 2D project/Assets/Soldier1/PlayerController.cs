using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJump;
    public int extraJumpValue;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        extraJump = extraJumpValue;
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        //Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.W)) //jump if player's on the ground and W button's pressed
        {
            anim.SetTrigger("jump"); 
        }
        if (isGrounded == true && Input.GetKeyDown(KeyCode.S)) //ROLL
        {
            anim.SetTrigger("isRolling");
        }

        if (moveInput == 0)//static anim: idle -> running anim = false
        {
            anim.SetBool("isRunning", false);
        }else{
            anim.SetBool("isRunning", true);// >0 anim: isRunning
        }

        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);//turn around by 180dgrs
        }else if(moveInput > 0){
            transform.eulerAngles = new Vector3(0, 0, 0);//default 0
        }



        //////////////SHOOT STAND//////////////
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("isShooting");
        }

    }
    void Update() // Update is called once per frame
    {
        if(isGrounded == true)
        {
            extraJump = extraJumpValue;
        }
        if (Input.GetKeyDown(KeyCode.W) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && extraJump == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        
    }
    
    
    void Turn()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    
}
