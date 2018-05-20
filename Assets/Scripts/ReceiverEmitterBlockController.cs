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
        _triggeredReceivers = new bool[_receivers.Count];
    }

    public void ActivateReceiver(int index)
    {
        _triggeredReceivers[index] = true;
        int numTriggered = 0;
        foreach (bool triggered in _triggeredReceivers)
        {
            if (triggered)
            {
                numTriggered++;
            }
        }

        if (numTriggered >= _requiredReceivers)
        {
            if (_debugText != null)
            {
                _debugText.text = "All receivers triggered";
            }

            foreach (GameObject emitter in _emitters)
            {
                emitter.SendMessage("FireLaser");
            }

            for (int i = 0; i < _triggeredReceivers.Length; i++)
            {
                _triggeredReceivers[i] = false;
            }
        }
    }

    public void DeactivateReceiver(int index)
    {
        if (_debugText != null)
        {
            _debugText.text = "";
        }
        
        _triggeredReceivers[index] = false;
    }
}
