using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject main;
    public GameObject settings;
    public GameObject login;
    public GameObject levels;
    public GameObject register;
    public GameObject benvenuto;
    public GameObject RankingGen;
    public GameObject RankingLvl1;
    public GameObject RankingLvl2;
    public GameObject RankingLvl3;
    public void PlayGame()
    {
        SceneManager.LoadScene("Space");
    }
    public void Settings()
    {
        main.SetActive(false);
        settings.SetActive(true);
    }
    public void Main()
    {
        main.SetActive(true);
        settings.SetActive(false);
        login.SetActive(false);
        levels.SetActive(false);
        register.SetActive(false);
        benvenuto.SetActive(false);
        RankingGen.SetActive(false);
        RankingLvl1.SetActive(false);
        RankingLvl2.SetActive(false);
        RankingLvl3.SetActive(false);
    }
    public void Login()
    {
        main.SetActive(false);
        login.SetActive(true);
        register.SetActive(false);
    }
    public void Register()
    {
        login.SetActive(false);
        register.SetActive(true);
    }
    public void Levels()
    {
        main.SetActive(false);
        levels.SetActive(true);
    }
    public void Benvenuto()
    {
        benvenuto.SetActive(true);
        register.SetActive(false);
        login.SetActive(false);
    }
    public void Rank()
    {
        main.SetActive(false);
        RankingGen.SetActive(true);
    }
    public void NextRank()
    {
        if(RankingGen.activeSelf==true)
        {
            RankingGen.SetActive(false);
            RankingLvl1.SetActive(true);
        }
        else if (RankingLvl1.activeSelf == true)
        {
            RankingLvl1.SetActive(false);
            RankingLvl2.SetActive(true);
        }
        else if (RankingLvl2.activeSelf == true)
        {
            RankingLvl2.SetActive(false);
            RankingLvl3.SetActive(true);
        }
    }
    public void PrevRank()
    {
        if (RankingLvl3.activeSelf == true)
        {
            RankingLvl3.SetActive(false);
            RankingLvl2.SetActive(true);
        }
        else if (RankingLvl2.activeSelf == true)
        {
            RankingLvl2.SetActive(false);
            RankingLvl1.SetActive(true);
        }
        else if (RankingLvl1.activeSelf == true)
        {
            RankingLvl1.SetActive(false);
            RankingGen.SetActive(true);
        }
    }
}
