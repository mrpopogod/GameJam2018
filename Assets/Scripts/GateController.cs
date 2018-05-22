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

    [SerializeField]
    private bool _doorStaysOpen;

    private float _triggerTime = -100.0f;
    private bool _noCloseDoorOpen = false;
	
    public void Energize()
    {
        if (_noCloseDoorOpen)
        {
            return;
        }

        if (Time.time > _triggerTime + _timeActive + _movementTime + _movementTime)
        {
            _triggerTime = Time.time;
            if (_doorStaysOpen)
            {
                _noCloseDoorOpen = true;
            }
        }
    }

	public void Update()
    {
        if (!_doorStaysOpen && Time.time > _triggerTime + _timeActive + _movementTime)
        {
            float current = _triggerTime + _timeActive + _movementTime + _movementTime - Time.time;
            if (current >= 0)
            {
                _rightDoor.gameObject.transform.localPosition = new Vector3(0.25f + current / _movementTime * 0.5f, _rightDoor.transform.localPosition.y, _rightDoor.transform.localPosition.z);
                _leftDoor.gameObject.transform.localPosition = new Vector3(-0.25f - current / _movementTime * 0.5f, _leftDoor.transform.localPosition.y, _leftDoor.transform.localPosition.z);
            }
        }
        else if (Time.time < _triggerTime + _movementTime)
        {
            float current = _triggerTime + _movementTime - Time.time;
            if (current >= 0)
            {
                _rightDoor.gameObject.transform.localPosition = new Vector3(0.75f - current / _movementTime * 0.5f, _rightDoor.transform.localPosition.y, _rightDoor.transform.localPosition.z);
                _leftDoor.gameObject.transform.localPosition = new Vector3(-0.75f + current / _movementTime * 0.5f, _leftDoor.transform.localPosition.y, _leftDoor.transform.localPosition.z);
            }
        }
        else if (!_doorStaysOpen && Time.time > _triggerTime + _timeActive + _movementTime + _movementTime)
        {
            _rightDoor.gameObject.transform.localPosition = new Vector3(0.25f, _rightDoor.transform.localPosition.y, _rightDoor.transform.localPosition.z);
            _leftDoor.gameObject.transform.localPosition = new Vector3(-0.25f, _leftDoor.transform.localPosition.y, _leftDoor.transform.localPosition.z);
        }
    }
}
