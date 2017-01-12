using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GUIFunctions : MonoBehaviour {
	public GameObject player;
	public Canvas deathScreen;
	public Canvas playerControls;

	void OnGUI()
	{
		if (player == null)
		{
			hide (playerControls);
			show (deathScreen);

			/*
			GUI.Box(new Rect(Screen.width/2-150, Screen.height/2-60, 300, 50), "You died");

			if(GUI.Button(new Rect(Screen.width/2-150, Screen.height/2, 300, 50), "Restart"))
			{
				Scene scene = SceneManager.GetActiveScene();
				SceneManager.LoadScene(scene.name);
			}
			*/

		}
	}

	void hide(Canvas obj){
		CanvasGroup canvas = obj.GetComponent<CanvasGroup>();
		canvas.alpha = 0f;
		canvas.blocksRaycasts = false;
	}

	void show(Canvas obj){
		CanvasGroup canvas = obj.GetComponent<CanvasGroup>();
		canvas.alpha = 1f;
		canvas.blocksRaycasts = true;
	}

}
