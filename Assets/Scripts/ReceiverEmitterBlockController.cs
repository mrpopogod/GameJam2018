using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiverEmitterBlockController : MonoBehaviour {

    [SerializeField]
    private List<GameObject> _receivers;

    [SerializeField]
    private List<GameObject> _emitters;

    [SerializeField]
    private Text _debugText;

    private bool[] _triggeredReceivers;

    public void Start()
    {
        _triggeredReceivers = new bool[_receivers.Count];
    }

    public void ActivateReceiver(int index)
    {
        _triggeredReceivers[index] = true;
        bool allTriggered = true;
        foreach (bool triggered in _triggeredReceivers)
        {
            if (!triggered)
            {
                allTriggered = false;
                break;
            }
        }

        if (allTriggered)
        {
            _debugText.text = "All receivers triggered";
            foreach (GameObject emitter in _emitters)
            {
                emitter.SendMessage("FireLaser");
            }
        }
    }

    public void DeactivateReceiver(int index)
    {
        _debugText.text = "";
        _triggeredReceivers[index] = false;
    }
}
