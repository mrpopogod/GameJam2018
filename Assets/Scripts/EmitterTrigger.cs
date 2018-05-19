using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterTrigger : MonoBehaviour {

    [SerializeField]
    private GameObject _shot;

    [SerializeField]
    private float _offset;

    public void FireLaser()
    {
        Debug.Log(name + " fire lasers!");
        Instantiate(_shot, transform.position + Vector3.right * _offset, transform.rotation * Quaternion.Euler(Vector3.left * 90.0f));
    }
}
