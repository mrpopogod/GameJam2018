using UnityEngine;

public class ReceiverTrigger : MonoBehaviour {

    [SerializeField]
    private int _index;

    [SerializeField]
    private float _timeActive;

    private float _triggerTime; 

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            _triggerTime = Time.time;
            GameObject parent = transform.parent.gameObject;
            parent.SendMessage("ActivateReceiver", _index);
            Destroy(other.gameObject);
        }
    }

    public void Update()
    {
        if (Time.time > _triggerTime + _timeActive)
        {
            GameObject parent = transform.parent.gameObject;
            parent.SendMessage("DeactivateReceiver", _index);
        }
    }
}
