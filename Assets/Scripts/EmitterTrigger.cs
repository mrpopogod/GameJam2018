using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterTrigger : MonoBehaviour {

    [SerializeField]
    private GameObject _shot;

    [SerializeField]
    private float _xOffset;

    [SerializeField]
    private float _yOffset;

    [SerializeField]
    private float _zOffset;

    public void FireLaser()
    {
        Instantiate(_shot, 
            transform.position + Vector3.right * _xOffset + Vector3.up * _yOffset + Vector3.forward * _zOffset, 
            transform.rotation * Quaternion.Euler(Vector3.left * 90.0f));
    }
}
