﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    float countTime;
    public float Limit = 0;
    float TimeLimit;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        TimeLimit = Limit - countTime;
        if (TimeLimit > 0.1)
        {
            GetComponent<TextMesh>().text = TimeLimit.ToString("F2");

        }
        else
        {
            FindObjectOfType<Score>().Save();
            GetComponent<TextMesh>().text = ("Finish");
            Time.timeScale = 0;
        }
    }
}
