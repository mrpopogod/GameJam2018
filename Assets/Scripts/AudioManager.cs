using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioClip[] laserSounds;

	public AudioSource audioSource;

	private int RandomInt(int x)
	{
		return ((int)(Random.value * x)) % x;
	}

	private T RandomElement<T>(T[] array)
	{
		return array[RandomInt(array.Length)];
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void PlayLaserSound()
	{
		audioSource.clip = RandomElement(laserSounds);
		audioSource.Play ();
	}
}
