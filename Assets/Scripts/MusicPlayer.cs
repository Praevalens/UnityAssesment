using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static bool AudioBegin = false; 

	void Awake()
	{
		if (!AudioBegin) {
			gameObject.GetComponent<AudioSource>().Play ();
			DontDestroyOnLoad (gameObject);
			AudioBegin = true;
		} 
	}

	void Update () {

	}
}
