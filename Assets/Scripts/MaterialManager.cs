using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour {

    [SerializeField]
    private Material _receiverMaterial;

    public Material receiverMaterial { get { return _receiverMaterial; } }

    [SerializeField]
    private Material _transmitterMaterial;

    public Material transmitterMaterial { get { return _transmitterMaterial; } }

    [SerializeField]
    private Material _rotateRightMaterial;

    public Material rotateRightMaterial { get { return _rotateRightMaterial; } }

    [SerializeField]
    private Material _rotateLeftMaterial;

    public Material rotateLeftMaterial { get { return _rotateLeftMaterial; } }

    [SerializeField]
    private Material _defaultMaterial;

    public Material defaultMaterial { get { return _defaultMaterial; } }

	[SerializeField]
	private Material _redMaterial;

	public Material redMaterial { get { return _redMaterial; } }

	[SerializeField]
	private Material _greenMaterial;

	public Material greenMaterial { get { return _greenMaterial; } }

	[SerializeField]
	private Material _blueMaterial;

	public Material blueMaterial { get { return _blueMaterial; } }
}
