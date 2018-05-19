using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float _speed;

    private Rigidbody _rb;
    private Vector3 _stop = new Vector3(0.0f, 0.0f, 0.0f);

    // Use this for initialization
    void Start () {
        _rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        int x = 0;
        int z = 0;
		if (Input.GetKey(KeyCode.W))
        {
            z = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            z = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            x = 1;
        }

        // TODO: multiplicand of speed should use pythagorus
        _rb.velocity = new Vector3(x * _speed, 0.0f, z * _speed);
    }
}
