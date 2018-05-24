using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioClip[] laserSounds;

    public AudioClip deathSound;

    public AudioClip teleportSound;

    private AudioSource[] laserSources;

    private AudioSource teleportSource;
    private AudioSource deathSource;

	private int RandomInt(int x)
	{
		return ((int)(Random.value * x)) % x;
	}
    private int lastLaserSource = 0;

	private T RandomElement<T>(T[] array)
	{
		return array[RandomInt(array.Length)];
	}

	// Use this for initialization
	void Start () {
        int laserSourceCount = 5;
        laserSources = new AudioSource[laserSourceCount];
        for (int i = 0; i < laserSourceCount; ++i)
            laserSources[i] = gameObject.AddComponent<AudioSource>();

        teleportSource = gameObject.AddComponent<AudioSource>();
        deathSource = gameObject.AddComponent<AudioSource>();

        teleportSource.clip = teleportSound;
        teleportSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void PlayLaserSound()
	{
        lastLaserSource = (lastLaserSource + 1) % laserSources.Length;
        laserSources[lastLaserSource].clip = RandomElement(laserSounds);
		laserSources[lastLaserSource].Play ();
	}

    public void PlayTeleportSound()
    {
        teleportSource.clip = teleportSound;
        teleportSource.Play();
    }
    public void PlayDeathSound()
    {
        deathSource.clip = deathSound;
        deathSource.Play();
    }
}
