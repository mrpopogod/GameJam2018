using UnityEngine;

public class Mover : MonoBehaviour {

    [SerializeField]
    private float _speed;

    private Rigidbody _rb;

	public float Speed { get { return _speed; } set { _speed = value; } }

    public void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = transform.up * _speed;
    }
}
