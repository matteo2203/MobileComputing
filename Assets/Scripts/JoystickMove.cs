using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    public GameObject AudioMotore;
    protected Joystick joystick;
    private float _horizontalInput = 0;
    private float _verticalInput = 0;
    public int movementSpeed = 0;
    public int rotationSpeed = 0;
 
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<FixedJoystick>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        AudioMotore.GetComponent<AudioSource>().mute = !(_horizontalInput != 0 || _verticalInput != 0);
            GetPlayerInput();
        
    }

    private void FixedUpdate()
    {
      
        
            RotatePlayer();
            MovePlayer();
        
    }


    private void GetPlayerInput()
    {
        _horizontalInput = joystick.Horizontal;
        _verticalInput = joystick.Vertical;
    }

    private void RotatePlayer()
    {
        float rotation = -_verticalInput * rotationSpeed;
        transform.Rotate(Vector3.forward * rotation);
    }

    private void MovePlayer()
    {
        if(_horizontalInput>0)
            rb2d.velocity = transform.right * Mathf.Round(_horizontalInput) * movementSpeed;
        else
            rb2d.velocity = transform.right * Mathf.Round(_horizontalInput) * (movementSpeed/2);
    }
}
