using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //タイマーとタイマーのスクリプトを名前指定で拾ってきて、スクリプトを有効にする
        GameObject.Find("Timer").GetComponent<Timer>().enabled = true;
        this.gameObject.SetActive(false);
        GameObject.Find("StartButton").gameObject.SetActive(false);

    }

}
