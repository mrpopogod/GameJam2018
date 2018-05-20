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

    private float _triggerTime = -100.0f;
	
    public void Energize()
    {
        if (Time.time > _triggerTime + _timeActive + _movementTime + _movementTime)
        {
            _triggerTime = Time.time;
        }
    }

	public void Update()
    {
        if (Time.time > _triggerTime + _timeActive + _movementTime)
        {
            float current = _triggerTime + _timeActive + _movementTime + _movementTime - Time.time;
            if (current >= 0)
            {
                _rightDoor.gameObject.transform.localPosition = new Vector3(0.25f + current / _movementTime * 0.5f, _rightDoor.gameObject.transform.localPosition.y, _rightDoor.gameObject.transform.localPosition.z);
                _leftDoor.gameObject.transform.localPosition = new Vector3(-0.25f - current / _movementTime * 0.5f, _leftDoor.transform.localPosition.y, _leftDoor.transform.localPosition.z);
            }
        }
        else if (Time.time < _triggerTime + _movementTime)
        {
            float current = _triggerTime + _movementTime - Time.time;
            if (current >= 0)
            {
                _rightDoor.gameObject.transform.localPosition = new Vector3(0.75f - current / _movementTime * 0.5f, _rightDoor.gameObject.transform.localPosition.y, _rightDoor.gameObject.transform.localPosition.z);
                _leftDoor.gameObject.transform.localPosition = new Vector3(-0.75f + current / _movementTime * 0.5f, _leftDoor.transform.localPosition.y, _leftDoor.transform.localPosition.z);
            }
        }
    }
}
