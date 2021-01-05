using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStat : MonoBehaviour
{
    public GameObject AudioStella;
    public GameObject AudioDanno;
    public GameObject AudioEsplosione;
    public GameObject AudioScudo;
    // Start is called before the first frame update
    public Rigidbody2D rb2d;
    public int health;
    public bool isInvincible = false;
    [SerializeField] private float invincibilityDurationSeconds;
    public GameObject hp3;
    public GameObject hp2;
    public GameObject hp1;
    public GameObject ship;
    public GameObject shield;
    public GameObject InterfaceUI;
    public GameObject LoseMenuUI;
    public GameObject WinMenuUI;
    public GameObject star1l;
    public GameObject star2l;
    public GameObject star3l;
    public GameObject star4l;
    public GameObject star5l;
    public GameObject star6l;
    public GameObject star1w;
    public GameObject star2w;
    public GameObject star3w;
    public GameObject star4w;
    public GameObject star5w;
    public GameObject star6w;
    public int starCount;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible)
        {
            shield.SetActive(true);
        }
        if (!isInvincible)
        {
            shield.SetActive(false);
        }
        if (health == 2)
        {
            Destroy(hp3);
        }
        if (health == 1)
        {
            Destroy(hp2);
        }
        if (health == 0)
        {
            Destroy(hp1);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Fore") {
            if (!isInvincible)
            {
                health -= 1;
                if (health <= 0)
                {
                    AudioEsplosione.GetComponent<AudioSource>().Play();
                    Die();
                }
                else
                    AudioDanno.GetComponent<AudioSource>().Play();
            }
            else
                AudioScudo.GetComponent<AudioSource>().Play();
            StartCoroutine(BecomeTemporarilyInvincible());
        }
        if (col.gameObject.tag == "End")
        {
            if (starCount >= 1)
            {
                star1w.SetActive(true);
                if (starCount >= 2)
                {
                    star2w.SetActive(true);
                    if (starCount >= 3)
                    {
                        star3w.SetActive(true);
                        if (starCount >= 4)
                        {
                            star4w.SetActive(true);
                            if (starCount >= 5)
                            {
                                star5w.SetActive(true);
                                if (starCount >= 6)
                                {
                                    star6w.SetActive(true);
                                }
                            }

                        }
                    }
                }

            }
            WinMenuUI.SetActive(true);
            Time.timeScale = 0f;
            InterfaceUI.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other )
    {
        if (other.tag == "Star")
        {
            AudioStella.GetComponent<AudioSource>().Play();
            starCount += 1;
            Destroy(other.gameObject);
        }
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("Player turned invincible!");
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDurationSeconds);

        isInvincible = false;
        Debug.Log("Player is no longer invincible!");
    }


        void Die()
    {
        if (starCount >= 1)
        {
            star1l.SetActive(true);
            if (starCount >= 2)
            {
                star2l.SetActive(true);
                if (starCount >= 3)
                {
                    star3l.SetActive(true);
                    if (starCount >= 4)
                    {
                        star4l.SetActive(true);
                        if (starCount >= 5)
                        {
                            star5l.SetActive(true);
                            if (starCount >= 6)
                            {
                                star6l.SetActive(true);
                            }
                        }
                       
                    }
                }
            }

        }
        LoseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        InterfaceUI.SetActive(false);
    }
        void Score()
    {
        if (starCount >= 1) 
        {
            GameObject.Find("SilverStar1").SetActive(true);


        }

    }
    
}
