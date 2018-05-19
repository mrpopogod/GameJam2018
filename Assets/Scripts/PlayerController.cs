using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float _playerSpeed;

    private Rigidbody _rb;

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
        _rb.velocity = new Vector3(x * _playerSpeed, 0.0f, z * _playerSpeed);
    }
}
