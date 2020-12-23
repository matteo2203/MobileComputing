using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TurretStat : MonoBehaviour
{
    public float delayTime;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStat>().Esplosione();
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerBullet")
            health--;
    }
}
