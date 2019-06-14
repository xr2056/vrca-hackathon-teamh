using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEplayback : MonoBehaviour {

    public AudioClip impact;
    AudioSource audioSource;


    void Start () {

        //AudioSourceコンポーネントを取得し、変数に格納
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            //指定したAudioClipを再生
            audioSource.PlayOneShot(impact, 0.5F);
        }
    }
}
