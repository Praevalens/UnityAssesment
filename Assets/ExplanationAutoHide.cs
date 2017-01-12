using UnityEngine;
using System.Collections;

public class ExplanationAutoHide : MonoBehaviour {
	float _time = 1.5f;

	void Update () {

		if (Time.timeSinceLevelLoad > 6) {
			gameObject.GetComponent<CanvasGroup> ().alpha -= Time.deltaTime/_time;
		} else {
			gameObject.GetComponent<CanvasGroup> ().alpha = 1f;
		}
	}
}
