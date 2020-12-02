using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSpaceShip : MonoBehaviour
{
    public Transform firePoint;
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
        InvokeRepeating("Shoot", 0.3f, 0.3f);
    }
    public void OnRelease()
    {
        CancelInvoke("Shoot");
    }
    public void Shoot()
    {
       
            Instantiate(bullet, firePoint.position, firePoint.rotation);


    }
}
