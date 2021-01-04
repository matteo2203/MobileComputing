using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public int strCount;
    public Transform lastCheckpointPos;
    public List<string> collected = new List<string>();
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
    void Destroy() 
    {
        Destroy(this);
    }

}
