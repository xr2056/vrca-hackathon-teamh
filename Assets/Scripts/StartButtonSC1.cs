using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonSC1 : MonoBehaviour {

    public AudioClip pushsound;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "hand")
        {
            //タイマーとタイマーのスクリプトを名前指定で拾ってきて、スクリプトを有効にする
            //GameObject.Find("Timer").GetComponent<Timer>().enabled = true;
            //this.gameObject.SetActive(false);

            StartCoroutine("startprocess");

        }
    }

    private IEnumerator startprocess()
    {
        audioSource.PlayOneShot(pushsound, 1.0F);
        yield return new WaitForSecondsRealtime(0.1f);
        SceneManager.LoadScene("ObjectScene");

    }
}
