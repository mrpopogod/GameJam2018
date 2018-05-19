using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRotator : MonoBehaviour {

    private Rigidbody _rb;

    // Use this for initialization
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        _rb.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        _rb.position = new Vector3(_rb.position.x, 0.0f, _rb.position.z);
    }
}
