using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonSC : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "hand")
        {
            //タイマーとタイマーのスクリプトを名前指定で拾ってきて、スクリプトを有効にする
            GameObject.Find("Timer").GetComponent<Timer>().enabled = true;
            this.gameObject.SetActive(false);
        }
    }
}
