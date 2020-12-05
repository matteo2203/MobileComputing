using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private bool isRunning;
    public GameObject RunningAudio;
    public float speed;
    public float jumpForce;
    public GameObject standIm;
    public GameObject crouchIm;
    public Transform shield;
    private float moveInput;
    Rigidbody2D rb2d;
    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public Animator anim;
    private enum State { idle, running, jumping,crouch}
    private State state;
    protected Joystick joystick;
    public static bool isCrouched = false;
    public Collider2D stand;
    public Collider2D crouch;
  
    // Start is called before the first frame update
    void Start()
    {
        isCrouched = false;
        joystick = FindObjectOfType<FixedJoystick>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        StateM();
            RunningAudio.GetComponent<AudioSource>().mute=!isRunning;
        anim.SetInteger("State", (int)state);
    }
    void FixedUpdate()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = joystick.Horizontal;
        if(!isCrouched)
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
       
        
    }
   public void Jump()
    {
        if (isGrounded == true && !isCrouched)
        {
            rb2d.velocity = Vector2.up * jumpForce;

        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    
    public void Crouch()
    {
        if (state != State.jumping)
        {
            if (isCrouched)
            {
                isCrouched = false;
                stand.enabled = true;
                crouch.enabled = false;
                crouchIm.SetActive(true);
                standIm.SetActive(false);
                shield.Rotate(0f, 0f, -90f);
                shield.position = new Vector3(shield.position.x, shield.position.y+0.6f, shield.position.z);

            }
            else
            {
                shield.Rotate(0f, 0f, 90f);
                shield.position = new Vector3(shield.position.x, shield.position.y-0.6f, shield.position.z);
                isCrouched = true;
                stand.enabled = false;
                crouch.enabled = true;
                crouchIm.SetActive(false);
                standIm.SetActive(true);

            }
        }
    }
    private void StateM()
    {
        if (!isGrounded)
        {
            state = State.jumping;
            isRunning = false;
        }
        else if (isCrouched)
        {
            state = State.crouch;
            isRunning = false;
        }
        else if (rb2d.velocity.x != 0)
        {
            state = State.running;
            isRunning =true;
        }
        else 
        {
            state = State.idle;
            isRunning = false;
        }
        

    }

}
