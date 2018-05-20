using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour {

    [SerializeField]
    private GameObject _leftDoor;

    [SerializeField]
    private GameObject _rightDoor;

    [SerializeField]
    private float _timeActive;

    [SerializeField]
    private float _movementTime;

    private float _triggerTime;
	
    public void Energize()
    {
        _triggerTime = Time.time;
    }

	public void Update()
    {
        if (Time.time > _triggerTime + _timeActive)
        {
            float current = _triggerTime + _timeActive + _movementTime + _movementTime - Time.time;
            if (current >= 0)
            {
                _rightDoor.gameObject.transform.position = new Vector3(0.25f + current / _movementTime * 0.5f, transform.position.y, transform.position.z);
                _leftDoor.gameObject.transform.position = new Vector3(-0.25f - current / _movementTime * 0.5f, transform.position.y, transform.position.z);
            }
        }
        else
        {
            float current = _triggerTime + _movementTime - Time.time;
            if (current >= 0)
            {
                _rightDoor.gameObject.transform.position = new Vector3(0.75f - current / _movementTime * 0.5f, transform.position.y, transform.position.z);
                _leftDoor.gameObject.transform.position = new Vector3(-0.75f + current / _movementTime * 0.5f, transform.position.y, transform.position.z);
            }
        }
    }
}
