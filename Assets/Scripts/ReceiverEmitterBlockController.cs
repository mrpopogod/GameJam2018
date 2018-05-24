using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiverEmitterBlockController : MonoBehaviour {

    public enum RotateDirection
    {
        None,
        Left,
        Right
    }

    [SerializeField]
    private RotateDirection _rotateDirection;

    [SerializeField]
    private List<GameObject> _receivers;

    [SerializeField]
    private List<GameObject> _linkedObjects;

    [SerializeField]
    private int _requiredReceivers;

    [SerializeField]
    private bool _isTarget;

    [SerializeField]
    private Text _debugText;

    private MaterialManager _materialManager;
    private uint _configuration = 0;
    private const uint RECEIVER = 1;
    private const uint EMITTER = 16;

    public void Start()
    {
        foreach (var emitter in _receivers)
        {
            _configuration = _configuration << 8;
            var component = emitter.GetComponent<ReceiverTrigger>();
            switch (component.triggerType)
            {
                case ReceiverTrigger.TriggerType.Receiver:
                    _configuration |= RECEIVER;
                    break;
                case ReceiverTrigger.TriggerType.Transmitter:
                    _configuration |= EMITTER;
                    break;
            }
        }

        _configuration = RotateLeft(_configuration, 8);
    }

    private uint RotateLeft(uint value, int count)
    {
        return (value << count) | (value >> (32 - count));
    }

    private uint RotateRight(uint value, int count)
    {
        return (value >> count) | (value << (32 - count));
    }

    private void SetMaterialManager()
    {
        var materialManagerObj = GameObject.Find("MaterialManager");
        if (materialManagerObj != null)
        {
            _materialManager = materialManagerObj.GetComponent<MaterialManager>();
        }
    }

    public void OnEnable()
    {
        SetMaterialManager();
        UpdateRotationIndicator();
    }

    //// Invoked when changes are made in inspector
    //public void OnValidate()
    //{
    //    UpdateRotationIndicator();
    //}

    private void UpdateRotationIndicator()
    {
        if (null == _materialManager)
        {
            SetMaterialManager();
        }

        var meshRenderer = GetComponent<MeshRenderer>();
        switch (_rotateDirection)
        {
            case RotateDirection.Left:
                meshRenderer.material = _materialManager.rotateLeftMaterial;
                break;
            case RotateDirection.Right:
                meshRenderer.material = _materialManager.rotateRightMaterial;
                break;
            case RotateDirection.None:
                meshRenderer.material = _materialManager.defaultMaterial;
                break;
        }
    }

    public void Update()
    {
        if (_isTarget)
        {
            var meshRenderer = GetComponent<MeshRenderer>();
            if (IsActive())
            {
                meshRenderer.material.color = Color.green;
            }
            else
            {
                meshRenderer.material.color = Color.red;
            }
        }
    }

    public void ReceiverActivated()
    {
        if (!IsActive())
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

        if (_rotateDirection == RotateDirection.Left)
        {
            _configuration = RotateLeft(_configuration, 8);
            foreach (var emitter in _receivers)
            {
                UpdateEmitter(emitter);
                _configuration = RotateLeft(_configuration, 8);
            }
        }
        else if (_rotateDirection == RotateDirection.Right)
        {
            _configuration = RotateRight(_configuration, 8);
            foreach (var emitter in _receivers)
            {
                UpdateEmitter(emitter);
                _configuration = RotateLeft(_configuration, 8);
            }
        }
    }

    private void UpdateEmitter(GameObject emitter)
    {
        var receiverTrigger = emitter.GetComponent<ReceiverTrigger>();
        if ((_configuration & RECEIVER) == RECEIVER)
        {
            receiverTrigger.triggerType = ReceiverTrigger.TriggerType.Receiver;
        }
        else if ((_configuration & EMITTER) == EMITTER)
        {
            receiverTrigger.triggerType = ReceiverTrigger.TriggerType.Transmitter;
        }
        else
        {
            receiverTrigger.triggerType = ReceiverTrigger.TriggerType.None;
        }

        receiverTrigger.OnValidate();
    }

    public bool IsActive()
    {
        int numOn = 0;
        foreach (var receiver in _receivers)
        {
            var trigger = receiver.GetComponent<ReceiverTrigger>();
            if (trigger.triggerType == ReceiverTrigger.TriggerType.Receiver && trigger.IsReceiverActive())
            {
                numOn++;
            }
        }

        return numOn >= _requiredReceivers;
    }
}
