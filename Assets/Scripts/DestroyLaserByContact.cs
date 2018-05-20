using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLaserByContact : MonoBehaviour {

    [SerializeField]
    private float _playerDelay;

    private float _spawnTime;

    public void Start()
    {
        _spawnTime = Time.time;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Receiver" || other.tag == "Glass" || other.tag == "Laser")
        {
            return;
        }
        else if (other.tag == "Player")
        {
            if (Time.time - _spawnTime < _playerDelay)
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
