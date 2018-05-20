using UnityEngine;

public class ReceiverTrigger : MonoBehaviour {

	public enum TriggerType
	{
		None,
		Receiver,
		Transmitter
	}

	public enum LaserType
	{
		GreenLaser,
		BlueLaser,
		RedLaser
	}

	[SerializeField]
	TriggerType _triggerType;

	public TriggerType triggerType { get { return _triggerType; } set { _triggerType = value; } }

	[SerializeField]
	LaserType _laserType;

	private MaterialManager _materialManager;

	// Receiver Fields

    [SerializeField]
    private float _timeActive;

	private MeshRenderer _indicatorRenderer;
	private float _lastLaserType;

    private float _triggerTime = -100.0f;

	// Transmitter Fields

	[SerializeField]
	private GameObject _shot;

	[SerializeField]
	private float _xOffset;

	[SerializeField]
	private float _yOffset;

	[SerializeField]
	private float _zOffset;

	private void SetMaterialManager()
	{
		_materialManager = GameObject.Find("MaterialManager").GetComponent<MaterialManager> ();
	}

	private void SetIndicator()
	{
		Transform trans = transform.Find("Indicator");
		if (null == trans)
			return;
		var indicator = trans.gameObject;
		if (null == indicator)
			return;
		_indicatorRenderer = indicator.GetComponent<MeshRenderer> ();
	}

	private void UpdateIndicator()
	{
		if (null == _indicatorRenderer) {
			Debug.Log ("null renderer");
			return;
		}
		switch (_triggerType) {
		case TriggerType.None:
			_indicatorRenderer.enabled = false;
			break;
		case TriggerType.Receiver:
			_indicatorRenderer.enabled = true;
			_indicatorRenderer.material = _materialManager.receiverMaterial;
			break;
		case TriggerType.Transmitter:
			_indicatorRenderer.enabled = true;
			_indicatorRenderer.material = _materialManager.transmitterMaterial;
			break;
		}
	}

	public bool IsReceiverActive()
	{
		return _triggerType == TriggerType.Receiver && (Time.time <= _triggerTime + _timeActive);
	}

	public void OnEnable()
	{
		SetMaterialManager();
		SetIndicator();
		UpdateIndicator();
	}

    public void OnTriggerEnter(Collider other)
    {
		Debug.Log ("OnTriggerEnter");
        if (other.tag == "Laser" && _triggerType == TriggerType.Receiver)
        {
            _triggerTime = Time.time;
            GameObject parent = transform.parent.gameObject;
			Debug.Log ("Send message");
            parent.SendMessage("ReceiverActivated");
            Destroy(other.gameObject);
        }
    }

	// Invoked when changes are made in inspector
	public void OnValidate()
	{
		UpdateIndicator();
	}

	public void FireLaser()
	{
		if (_triggerType != TriggerType.Transmitter)
        {
            return;
        }

		Debug.LogFormat ("Firing: {0}", _triggerType);
		Instantiate(_shot, 
			transform.position + Vector3.right * _xOffset + Vector3.up * _yOffset + Vector3.forward * _zOffset, 
			transform.rotation * Quaternion.Euler(Vector3.left * 90.0f));
	}
}
