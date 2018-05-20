using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLaserByContact : MonoBehaviour {

    private float _spawnTime;

    public void Start()
    {
        _spawnTime = Time.time;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Receiver" || other.tag == "Glass")
        {
            return;
        }
        else if (other.tag == "Player")
        {
            if (Time.time - _spawnTime < 0.05f)
            {
                return;
            }
            else
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }

        Destroy(gameObject);
    }
}
