using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fluttuamentazione : MonoBehaviour
{
    public float speed;
    float altezza;
    public float amplitude;
    // Start is called before the first frame update
    void Start()
    {
        altezza = transform.position.y;
        Vector3 p = transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        // Put the floating movement in the Update function:

        transform.position = new Vector3(transform.position.x, altezza + amplitude * Mathf.Sin(speed * Time.time),transform.position.z) ;
    }
}
