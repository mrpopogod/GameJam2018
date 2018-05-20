using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float _playerSpeed;

    [SerializeField]
    private GameObject _shot;

    [SerializeField]
    private Transform _shotSpawn;

    [SerializeField]
    private float _fireRate;

    [SerializeField]
    private Text _debugText;

    private Rigidbody _rb;
    private float _nextFire;

    public void Start () {
        _rb = GetComponent<Rigidbody>();
    }

    public void Update ()
    {
        UpdateVelocity();
        HandleShot();
    }

    private void HandleShot()
    {
        if (Input.GetButton("Fire1") && Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;

            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector3 angleToMouse = lookPos - transform.position;
            float angle = Mathf.Atan2(angleToMouse.z, angleToMouse.x) * Mathf.Rad2Deg;
            // On the shape, Z=0 is up on the playfield, so subtract 90 to have it be pointing to the right of the playfield;
            // that way the calculation is correct
            Quaternion finalAngle = Quaternion.Euler(90.0f, 0.0f, angle - 90.0f);
            GameObject shot = Instantiate(_shot, _shotSpawn.position , finalAngle);
        }
    }

    private void UpdateVelocity()
    {
        int x = 0;
        int z = 0;
        if (Input.GetKey(KeyCode.W))
        {
            z += 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            z -= 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            x -= 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            x += 1;
        }

        // TODO: multiplicand of speed should use pythagorus

        _rb.velocity = new Vector3(x * _playerSpeed, 0.0f, z * _playerSpeed);
    }
}
