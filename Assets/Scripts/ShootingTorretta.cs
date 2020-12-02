using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTorretta : MonoBehaviour
{
    public float ShootingSpeed;
    public Transform firePoint;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0.3f, ShootingSpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Shoot()
    {

        Instantiate(bullet, firePoint.position, firePoint.rotation);


    }
}
