using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Score : MonoBehaviour
{

    public GameObject count;
    public LayerMask m_LayerMask;
    float[] scores = new float[20];

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        MyCollisions();
    }

    private void MyCollisions()
    {
        Collider[] colliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);

        for (int i = 0; i < colliders.Length; i++)
        {
            float score = colliders[i].transform.position.y;
            scores[i] = score;

        }
        MaxScore();
    }

    void MaxScore()
    {
        float results = scores.Max();
        count.GetComponent<TextMesh>().text = results.ToString("F2");
    }
}
