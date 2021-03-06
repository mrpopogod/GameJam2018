﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {


	public enum Type
	{
		Any,
		Green,
		Blue,
		Red
	}

	[SerializeField]
	Type _type;

	[SerializeField]
	private GameObject _source;
	public GameObject Source { get { return _source; } set { _source = value; } }

	Mover _mover;
	Renderer _renderer;
	MaterialManager _materials;
	private AudioManager _audioManager;

	private void SetMover()
	{
		_mover = GetComponent <Mover> ();
		if (null == _mover)
			Debug.LogError ("Null mover!");
	}
	private void SetRenderer()
	{
		_renderer = GetComponent<Renderer> ();
	}
	private void SetMaterials()
	{
		_materials = GameObject.Find ("MaterialManager").GetComponent<MaterialManager> ();
	}
	private void SetAudioManager()
	{
		_audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager> ();
	}

	private void SetAll()
	{
		SetMover ();
		SetRenderer ();
		SetAudioManager ();
		SetMaterials ();
	}

	public Type LaserType {
		get { return _type; }
		set {
			if (null == _mover)
				SetAll ();

			_type = value;
			switch (_type) {
			case Type.Any:
				_mover.Speed = 10;
				_renderer.material = _materials.defaultMaterial;
				break;
			case Type.Red:
				_mover.Speed = 20;
				_renderer.material = _materials.redMaterial;
				break;
			case Type.Green:
				_mover.Speed = 5;
				_renderer.material = _materials.greenMaterial;
				break;
			case Type.Blue:
				_mover.Speed = 15;
				_renderer.material = _materials.blueMaterial;
				break;
			default:
				Debug.Assert (false, "Unhandled laser type");
				break;
			}
		}
	}

	// Use this for initialization
	void Start () {
		if (null == _audioManager)
			SetAll ();
        if (this.ToString() == "LaserNoSound")
        {
            return;
        }
		_audioManager.PlayLaserSound ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
