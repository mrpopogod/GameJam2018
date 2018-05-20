using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour {

    [SerializeField]
    private List<GameObject> _triggers;

    private bool _isActive;

	public void Update ()
    {
        if (_isActive)
        {
            return;
        }

        bool allActive = true;
		foreach (var trigger in _triggers)
        {
            var receiverBlockController = trigger.GetComponent<ReceiverEmitterBlockController>();
            if (receiverBlockController != null)
            {
                if (!receiverBlockController.IsActive())
                {
                    allActive = false;
                    break;
                }
            }

            // Other trigger types here
        }

        if (allActive)
        {
            _isActive = true;
            transform.position = new Vector3(transform.position.x, transform.position.y + 1.05f, transform.position.z);
        }
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Finished level!");
        }
    }
}
