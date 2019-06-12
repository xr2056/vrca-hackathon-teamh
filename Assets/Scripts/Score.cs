using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Score : MonoBehaviour
{

    public GameObject count;
    public GameObject highScoreText;
    public LayerMask m_LayerMask;
    float[] scores = new float[20];
    float score;
    float highScore;
    private string highScoreKey = "highScore";

    // Use this for initialization
    void Start()
    {
        Initialize();

        highScore = PlayerPrefs.GetFloat(highScoreKey, 0);
    }

    // Update is called once per frame
    void Update()
    {
    
        highScoreText.GetComponent<TextMesh>().text = highScore.ToString("F2");
    }

    private void Initialize()
    {
        // ハイスコアを取得する。保存されてなければ0を取得する。
        highScore = PlayerPrefs.GetFloat(highScoreKey, 0);
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
        float score = scores.Max();
        count.GetComponent<TextMesh>().text = score.ToString("F2");

        if (highScore < score)
        {
            highScore = score;
        }
    }

    public void Save()
    {
        // ハイスコアを保存する
        PlayerPrefs.SetFloat(highScoreKey, highScore);
        PlayerPrefs.Save();

        // ゲーム開始前の状態に戻す
        //Initialize();
    }
}
