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

		// Laser can't destroy it's source right after firing
		var laser = GetComponent<Laser> ();
		if (null != laser && laser.Source == other.gameObject && Time.time - _spawnTime < _playerDelay)
			return;
		

		if (other.tag == "Player")
        {
			Destroy(other.gameObject);
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayDeathSound();
        }

        Destroy(gameObject);
    }
}
