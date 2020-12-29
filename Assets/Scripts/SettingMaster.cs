using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class SettingMaster : MonoBehaviour
{
    // Start is called before the first frame update
    public string nome;
    public float prefMaster;
    public float prefMusic;
    public float prefEffect;
    public AudioMixer audioMixer;
    private static SettingMaster instance;
    private GameObject[] TextUtenti;
    public bool isEasy=true;
    void Update()
    {
        TextUtenti = GameObject.FindGameObjectsWithTag("NomeUtente");
        if (nome == null)
            nome = "not logged";
        foreach(GameObject o in TextUtenti)
        {
             o.GetComponent<TextMeshProUGUI>().text=nome;
        }
    }
    void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
            Destroy(gameObject);
    }
    public void ToggleEasy()
    {
        if (isEasy)
        {
            
           
            isEasy = false;
        }
        else
        {
            
            
            isEasy = true;
        }
    }
  
    public void SetVolumeMaster(float volumeMaster)
    {
        audioMixer.SetFloat("volumeMaster", volumeMaster);
        prefMaster = volumeMaster;
    }
    public void SetVolumeEffects(float volumeEffects)
    {
        audioMixer.SetFloat("volumeEffects", volumeEffects);
        prefEffect = volumeEffects;
    }
    public void SetVolumeMusic(float volumeMusic)
    {
        audioMixer.SetFloat("volumeMusic", volumeMusic);
        prefMusic = volumeMusic;
    }

}
