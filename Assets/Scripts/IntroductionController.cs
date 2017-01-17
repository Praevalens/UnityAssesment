using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class IntroductionController : MonoBehaviour {

	public GameObject text1;
	public GameObject text2;
	public GameObject text3;
	public GameObject text4;
	private int iterator = 1;

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			switch (iterator) {
			case 1: 
				text1.GetComponent<CanvasGroup> ().alpha = 0;
				text2.GetComponent<CanvasGroup> ().alpha = 1;
				iterator++;
				break;
			case 2: 
				text2.GetComponent<CanvasGroup> ().alpha = 0;
				text3.GetComponent<CanvasGroup> ().alpha = 1;
				iterator++;
				break;
			case 3: 
				text3.GetComponent<CanvasGroup> ().alpha = 0;
				text4.GetComponent<CanvasGroup> ().alpha = 1;
				iterator++;
				break;
			case 4: 
				SceneManager.LoadScene ("Level-1");
				break;
			}

		};
	}
}
