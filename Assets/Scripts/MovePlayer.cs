using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MovePlayer : MonoBehaviour
{
    protected Joystick joystick;
    private float _horizontalInput = 0;
    private float _verticalInput = 0;
    public float jumpForce;
    public float movementSpeed;
    public Animator anim;
    private enum State { idle,running,jumping}
    private State state;
    Rigidbody2D rb2d;
    [SerializeField] private LayerMask layers;
    private Collider2D coll;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<FixedJoystick>();
        rb2d = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        state = State.idle;
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        StateM();
        anim.SetInteger("State",(int)state);
    }
    void FixedUpdate()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        isGrounded = true;

    }

    void GetPlayerInput()
    {
        _horizontalInput = joystick.Horizontal;
        _verticalInput = joystick.Vertical;
    }
    void Jump()
    {
      
       
        
    }
    
    private void StateM()
    {
        if (Math.Abs(rb2d.velocity.y)>2)
        {
            state = State.jumping;
        }
        else if (rb2d.velocity.x != 0)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
        
    }
    
}
