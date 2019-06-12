using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        int layernunber = collision.gameObject.layer;
        //Debug.Log(layernunber);
        if (layernunber == 9)
        {
            this.gameObject.layer = 9;
        }

    }
}
