using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiverEmitterBlockController : MonoBehaviour {

    [SerializeField]
    private List<GameObject> _receivers;

    [SerializeField]
    private List<GameObject> _linkedObjects;

    [SerializeField]
    private int _requiredReceivers;

    [SerializeField]
    private Text _debugText;

    public void ReceiverActivated()
    {
        int numOn = 0;
        foreach (var receiver in _receivers) {
			var trigger = receiver.GetComponent<ReceiverTrigger> ();
			if (trigger.triggerType == ReceiverTrigger.TriggerType.Receiver && trigger.IsReceiverActive ()) {
                numOn++;
			}
		}

        if (numOn < _requiredReceivers)
        {
            return;
        }

		foreach (var emitter in _receivers) {
			emitter.GetComponent<ReceiverTrigger>().SendMessage ("FireLaser");
		}

        foreach (var gameObject in _linkedObjects)
        {
            gameObject.SendMessage("Energize");
        }
    }
}
