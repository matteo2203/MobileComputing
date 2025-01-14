﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gm.lastCheckpointPos = transform;
            gm.strCount = other.gameObject.GetComponent<PlayerStat>().starCount;
            gm.collected = other.gameObject.GetComponent<PlayerStat>().collected;
        }
    }
}

