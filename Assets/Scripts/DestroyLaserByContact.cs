using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLaserByContact : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Receiver" || other.tag == "Glass")
        {
            return;
        }

        Destroy(gameObject);
    }
}
