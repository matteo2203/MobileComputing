using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointList : MonoBehaviour
{
    private SettingMaster sm;
    public GameObject Checkpoints;
    // Start is called before the first frame update
    void Start()
    {
        sm= GameObject.FindGameObjectWithTag("SM").GetComponent<SettingMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sm.isEasy)
        {
            Checkpoints.SetActive(true);
        }
        else
            Checkpoints.SetActive(false);
    }
}
