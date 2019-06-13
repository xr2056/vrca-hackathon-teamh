using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    float countTime;
    public float Limit = 0;
    float TimeLimit;

    //ui用に追加
    public GameObject ui;
    public GameObject restartbutton;

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

            //ui用に追加
            StartCoroutine("UI");
        }
    }


    //ui用に追加
    private IEnumerator UI()
    {
        yield return new WaitForSecondsRealtime(5.0f);
        ui.SetActive(true);
        yield return new WaitForSecondsRealtime(5.0f);
        Time.timeScale = 1;
        restartbutton.SetActive(true);

    }
}
