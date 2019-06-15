using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CountDownSC : MonoBehaviour
{
    [SerializeField]
    private TextMesh _textCountdown;

    void Start()
    {
        _textCountdown.text = "";
        StartCoroutine(CountdownCoroutine());
    }
    
    IEnumerator CountdownCoroutine()
    {
        //_imageMask.gameObject.SetActive(true);
        _textCountdown.gameObject.SetActive(true);

        _textCountdown.text = "3";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "2";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "1";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "GO!";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "";
        _textCountdown.gameObject.SetActive(false);
        GameObject.Find("Timer").GetComponent<Timer>().enabled = true;
    }
}