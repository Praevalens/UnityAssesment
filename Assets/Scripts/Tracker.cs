﻿using UnityEngine;

public class Tracker : MonoBehaviour {

	public GameObject goToTrack;

	void Update () {
		
	}

	void OnGUI(){
		Vector3 v3Screen = Camera.main.WorldToViewportPoint(goToTrack.transform.position);
		Renderer rend = (Renderer)gameObject.GetComponent<Renderer>();

		if (v3Screen.x > -0.01f && v3Screen.x < 1.01f && v3Screen.y > -0.01f && v3Screen.y < 1.01f) {
			rend.enabled = false;
		}
		else
		{
			rend.enabled = true;
			v3Screen.x = Mathf.Clamp (v3Screen.x, 0.01f, 0.99f) -0.1f;
			v3Screen.y = Mathf.Clamp (v3Screen.y, 0.01f, 0.99f) -0.1f;
			transform.position = Camera.main.ViewportToWorldPoint (v3Screen);
		}

	}
}