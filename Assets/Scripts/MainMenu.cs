using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void startGame(){
		SceneManager.LoadScene ("level-1");
	}

	public void showControls(){
		SceneManager.LoadScene ("ControlExplanations");
	}

	public void showMenu(){
		SceneManager.LoadScene ("MainMenu");
	}
}
