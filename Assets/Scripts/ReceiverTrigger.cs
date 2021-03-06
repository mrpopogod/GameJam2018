﻿using UnityEngine;

public class ReceiverTrigger : MonoBehaviour {

	public enum TriggerType
	{
		None,
		Receiver,
		Transmitter
	}


	[SerializeField]
	TriggerType _triggerType;

	public TriggerType triggerType { get { return _triggerType; } set { _triggerType = value; } }

	[SerializeField]
	Laser.Type _laserType;

	private MaterialManager _materialManager;

	// Receiver Fields

    [SerializeField]
    private float _timeActive;

	private MeshRenderer _indicatorRenderer;

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

		Color c;
		switch (_laserType) {
		case Laser.Type.Any:
			c = Color.black;
			break;
		case Laser.Type.Red:
			c = Color.red;
			break;
		case Laser.Type.Green:
			c = Color.green;
			break;
		case Laser.Type.Blue:
			c = Color.blue;
			break;
		default:
			Debug.Assert (false, "Unhandled laser type");
			c = Color.black;
			break;
		}
		_indicatorRenderer.material.color = c;
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
			Laser laser = other.GetComponent<Laser> ();
			if (_laserType != Laser.Type.Any && laser.LaserType != Laser.Type.Any && laser.LaserType != _laserType)
				return;
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
			
		var shot = Instantiate(_shot, 
			transform.position + Vector3.right * _xOffset + Vector3.up * _yOffset + Vector3.forward * _zOffset, 
			transform.rotation * Quaternion.Euler(Vector3.left * 90.0f));
		var laser = shot.GetComponent<Laser> ();
		laser.Source = gameObject;
		laser.LaserType = _laserType;
	}
}
