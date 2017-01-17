using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void startGame(){
		SceneManager.LoadScene ("Introduction");
	}

	public void showControls(){
		SceneManager.LoadScene ("ControlExplanations");
	}

	public void showMenu(){
		SceneManager.LoadScene ("MainMenu");
	}

	public void loadLevel1(){
		SceneManager.LoadScene ("level-1");
	}

	public void loadLevel2(){
		SceneManager.LoadScene ("level-2");
	}

	public void loadLevel3(){
		SceneManager.LoadScene ("level-3");
	}

	public void loadLevel4(){
		SceneManager.LoadScene ("level-4");
	}

}
