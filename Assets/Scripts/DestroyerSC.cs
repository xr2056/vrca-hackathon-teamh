using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerSC : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "tsumiki")
        {
            Destroy(other.gameObject);
        }
    }
}
