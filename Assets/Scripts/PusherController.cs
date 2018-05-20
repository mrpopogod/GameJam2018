using UnityEngine;

public class PusherController : MonoBehaviour {

    [SerializeField]
    private GameObject _face;

    [SerializeField]
    private float _movementTime;

    private float _triggerTime = -100.0f;

    public void Energize()
    {
        _triggerTime = Time.time;
    }

    public void Update()
    {
        if (Time.time > _triggerTime + _movementTime)
        {
            float current = _triggerTime + _movementTime + _movementTime - Time.time;
            if (current >= 0)
            {
                _face.gameObject.transform.localPosition = new Vector3(0.38f + current / _movementTime, _face.gameObject.transform.localPosition.y, _face.gameObject.transform.localPosition.z);
            }
        }
        else if (Time.time < _triggerTime + _movementTime)
        {
            float current = _triggerTime + _movementTime - Time.time;
            if (current >= 0)
            {
                _face.gameObject.transform.localPosition = new Vector3(1.38f - current / _movementTime, _face.gameObject.transform.localPosition.y, _face.gameObject.transform.localPosition.z);
            }
        }
    }
}
