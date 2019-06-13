using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Score : MonoBehaviour
{

    public GameObject count;
    public GameObject highScoreText;
    public GameObject result;
    public LayerMask m_LayerMask;
    float[] scores = new float[20];
    float score;
    float highScore;
    private string highScoreKey = "highScore";

    // Use this for initialization
    void Start()
    {
        //Initialize();

        //保存されているハイスコアの取得
        //highScoreKeyに保存されているFloatの値をhighScoreに入れる。保存されていなければ0を取得する。
        highScore = PlayerPrefs.GetFloat(highScoreKey, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //ハイスコアを小数点第二位まで表示
        highScoreText.GetComponent<TextMesh>().text = highScore.ToString("F2");
    }
/*
    private void Initialize()
    {
        // ハイスコアを取得する。保存されてなければ0を取得する。
        highScore = PlayerPrefs.GetFloat(highScoreKey, 0);
    }
*/
    void FixedUpdate()
    {
        MyCollisions();
    }

    private void MyCollisions()
    {   
        //指定した箱型のエリアに接触している物理機能を持ったオブジェクトの座標を保管する
        //OverlapBox(判定エリアの中心の座標,判定エリアの各辺の2/1,判定エリアの角度,対象とするレイヤーマスク)
        Collider[] colliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);

        //collidersの中身をすべて取り出す
        for (int i = 0; i < colliders.Length; i++)
        {
            //保存されている座標からy座標のみ取り出してfloatにする
            float score = colliders[i].transform.position.y;
            //配列に追加
            scores[i] = score;

        }
        MaxScore();
    }

    void MaxScore()
    {
        //リンクで最大値を取得
        float score = scores.Max();
        count.GetComponent<TextMesh>().text = score.ToString("F2");
        result.GetComponent<TextMesh>().text = score.ToString("F2");

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
