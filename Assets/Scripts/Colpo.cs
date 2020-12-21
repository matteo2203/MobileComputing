using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colpo : MonoBehaviour
{
    public float velocita = 20f;
    public Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d.velocity = transform.right * velocita;
       
    }
    void Awake()
    {
        //FindObjectOfType<SettingMaster>().Play("Colpo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Star" && col.tag != "HP")
        {
            Destroy(gameObject);
        }

    }
}
