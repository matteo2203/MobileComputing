using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class AudioSettingsModMaster : MonoBehaviour
{
    public Slider s;
    private float volume;
    private SettingMaster sm;
    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.FindGameObjectWithTag("SM").GetComponent<SettingMaster>();
        s.value = sm.prefMaster;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Awake()
    {


    }
}