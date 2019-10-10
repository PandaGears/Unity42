using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance{ get; private set; }
	private AudioSource source;


	void Awake()
	{
		instance = this;
		source = GetComponent<AudioSource> ();
	}
	public void Play()
	{
		source.Play ();
	}
	public void Stop()
	{
		source.Stop ();
	}


}
