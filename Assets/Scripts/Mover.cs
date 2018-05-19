using UnityEngine;

public class Mover : MonoBehaviour {

    [SerializeField]
    private float _speed;

    private Rigidbody _rb;

    public void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = transform.up * _speed;
    }
}
