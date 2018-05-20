using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiverEmitterBlockController : MonoBehaviour {

    [SerializeField]
    private List<GameObject> _receivers;

    [SerializeField]
    private List<GameObject> _emitters;

    [SerializeField]
    private int _requiredReceivers;

    [SerializeField]
    private Text _debugText;

    private bool[] _triggeredReceivers;

    public void Start()
    {
        //_triggeredReceivers = new bool[_receivers.Count];
    }

    public void ReceiverActivated()
    {
		foreach (var receiver in _receivers) {
			var trigger = receiver.GetComponent<ReceiverTrigger> ();
			if (trigger.triggerType == ReceiverTrigger.TriggerType.Receiver && !trigger.IsReceiverActive ()) {
				Debug.Log ("Receiver not active");
				return;
			}
		}
		foreach (var emitter in _receivers) {
			emitter.GetComponent<ReceiverTrigger>().SendMessage ("FireLaser");
		}
    }
}
