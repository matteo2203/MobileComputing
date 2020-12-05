using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{  // Start is called before the first frame update
    public GameObject DannoAudio;
    public GameObject ShieldAudio;
    public GameObject StellaAudio;
    public Rigidbody2D rb2d;
    public int health;
    public float delayTime;
    public bool isInvincible = false;
    public bool test = false;
    [SerializeField] private float invincibilityDurationSeconds;
    public GameObject hp3;
    public GameObject hp2;
    public GameObject hp1;
    public GameObject player;
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
    private GameMaster gm;
    public List<string> collected = new List<string>();

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckpointPos.position+ new Vector3(0f,2f,0f);
        if (GameObject.FindGameObjectWithTag("Respawn").transform.position + new Vector3(0f, 2f,0f)==transform.position)
        {

        }
        else
        {
            starCount = gm.strCount;
            collected = gm.collected;
            foreach (string nom in collected)
            {
                GameObject.Find(nom).SetActive(false);
            }
        }
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
        if (health==3)
        {
            hp3.SetActive(true);
        }
        if (health == 2)
        {
            hp3.SetActive(false);
            hp2.SetActive(true);
        }
        if (health == 1)
        {
            hp2.SetActive(false);
            hp1.SetActive(true);
        }
        if (health == 0)
        {
            hp1.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyBullet")
        {
            if (!isInvincible)
            {
                health -= 1;

                if (health <= 0)
                {
                    StartCoroutine(Die());
                }
                DannoAudio.GetComponent<AudioSource>().Play();
                StartCoroutine(BecomeTemporarilyInvincible());
            }
            else
                ShieldAudio.GetComponent<AudioSource>().Play();
        }
        if (col.tag == "HP")
        {
            if (health < 3)
            {
                health++;
                col.gameObject.SetActive(false);
                collected.Add(col.gameObject.name);
            }
            else
            {
                StellaAudio.GetComponent<AudioSource>().Play();
                starCount++;
                col.gameObject.SetActive(false);
                collected.Add(col.gameObject.name);
            }
        }
        if (col.tag == "Star")
        {
            StellaAudio.GetComponent<AudioSource>().Play();
            starCount += 1;
            col.gameObject.SetActive(false);
            collected.Add(col.gameObject.name);
        }




    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "abisso")
        {
            Debug.Log("L hai toccato!");
            StartCoroutine(Die());

        }

        if (col.gameObject.tag == "End")
        {
            WinMenuUI.SetActive(true);
            Time.timeScale = 0f;
            InterfaceUI.SetActive(false);
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


    private IEnumerator Die()
    {
        if (test)
        {
            yield break;
        }
        test = true;
        LoseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        InterfaceUI.SetActive(false);
        if (starCount >= 1)
        {
            yield return new WaitForSecondsRealtime(delayTime);
            star1l.SetActive(true);
            if (starCount >= 2)
            {
                yield return new WaitForSecondsRealtime(delayTime);
                star2l.SetActive(true);
                if (starCount >= 3)
                {
                    yield return new WaitForSecondsRealtime(delayTime);
                    star3l.SetActive(true);
                    if (starCount >= 4)
                    {
                        yield return new WaitForSecondsRealtime(delayTime);
                        star4l.SetActive(true);
                        if (starCount >= 5)
                        {
                            yield return new WaitForSecondsRealtime(delayTime);
                            star5l.SetActive(true);
                            if (starCount >= 6)
                            {
                                yield return new WaitForSecondsRealtime(delayTime);
                                star6l.SetActive(true);
                            }
                        }

                    }
                }
            }

        }
        test = false;
    }
    public void Esplosione()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
    }
   
}
