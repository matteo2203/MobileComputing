using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePointStand;
    public Transform firePointCrouch;
    public GameObject bullet;
    private bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void ToggleIsPressed(bool value)
    {
        isPressed = value;
    }
    public void OnPress()
    {
        InvokeRepeating("Shoot", 0.0f, 0.6f);
    }
    public void OnRelease() {
        CancelInvoke("Shoot");
    }
    public void Crouch()
    {

    }
    public void Shoot()
    {
        if (!PlayerController.isCrouched) 
            Instantiate(bullet, firePointStand.position, firePointStand.rotation);
        else
            Instantiate(bullet, firePointCrouch.position, firePointCrouch.rotation);

    }
}
