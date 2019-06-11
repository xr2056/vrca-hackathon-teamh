using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentNull : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "floor")
            transform.parent = null;
    }

}