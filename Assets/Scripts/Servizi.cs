using System.Net;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Servizi : MonoBehaviour
{
    public Boolean userExist;
    public Boolean userRegistered;
    public string nome;
    public TMP_InputField nomFieldLog;
    public TMP_InputField pswFieldLog;
    public TMP_InputField nomFieldReg;
    public TMP_InputField pswFieldReg;
    void Start()
    {

    }

    //Qui le funzioni di giacomino
    
    public void getUserFromServer()
    {

        HttpWebRequest request =
            (HttpWebRequest)WebRequest.Create(
                string.Format("https://mobilecomputingapp.herokuapp.com/getUser?nome={0}&password={1}", nomFieldLog.text, pswFieldLog.text));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonString = reader.ReadToEnd();
        if (response.StatusCode == HttpStatusCode.OK)
        {
            Debug.Log(jsonString);
            userExist = true;
            this.nome = nomFieldLog.text;
            this.gameObject.GetComponent<Menu>().Benvenuto();
            GameObject.FindGameObjectWithTag("SM").GetComponent<SettingMaster>().nome = nome;
        }
        else
        {
            userExist = false;
        }
    }


     public void registerUser()
    {
        HttpWebRequest request =
               (HttpWebRequest)WebRequest.Create(
                   string.Format("https://mobilecomputingapp.herokuapp.com/creaUser?nome={0}&password={1}", nomFieldReg.text, pswFieldReg.text));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonString = reader.ReadToEnd();
        if (response.StatusCode == HttpStatusCode.OK)
        {
            Debug.Log(jsonString);
            userRegistered = true;
            this.nome = nomFieldReg.text;
            this.gameObject.GetComponent<Menu>().Benvenuto();
            GameObject.FindGameObjectWithTag("SM").GetComponent<SettingMaster>().nome = nome;
        }
        else
        {
            userRegistered = false;
        }
    }

    public void getLivelli()
    {

    }

    public void getScorePerUtente()
    {

    }
}

[Serializable]
public class User
{
    public int id;
    public string nome;
    public string psw;
}