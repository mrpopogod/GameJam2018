using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float _playerSpeed;

    [SerializeField]
    private GameObject _shot;

    [SerializeField]
    private Transform _shotSpawn;

	[SerializeField]
	private Laser.Type _laserType;

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
        CheckForRestart();
        CheckForLevelSelect();
    }

    private void CheckForRestart()
    {
        if (Input.GetKey(KeyCode.G))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }

    private void CheckForLevelSelect()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync("0.Level Select");
        }
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
            var shot = Instantiate(_shot, _shotSpawn.position , finalAngle);
			var laser = shot.GetComponent<Laser> ();
			laser.Source = gameObject;
			laser.LaserType = _laserType;
        }
    }

    private void UpdateVelocity()
    {
        float x = 0;
        float z = 0;
        bool posZ = Input.GetKey(KeyCode.W);
        bool negZ = Input.GetKey(KeyCode.S);
        bool moveZ = posZ != negZ;
        bool posX = Input.GetKey(KeyCode.D);
        bool negX = Input.GetKey(KeyCode.A);
        bool moveX = posX != negX;
        float amount = _playerSpeed;
        if (moveZ && moveX)
            amount = Mathf.Sqrt(2*amount);
        if (moveZ)
            z = posZ ? amount : -amount;
        if (moveX)
            x = posX ? amount : -amount;

        _rb.velocity = new Vector3(x, 0.0f, z);
    }
}
