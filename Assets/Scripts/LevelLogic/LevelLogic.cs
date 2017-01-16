using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class LevelLogic : MonoBehaviour {
	const int rocketFuelMax = 300;
	public int startingFuel = 300;
	const int boostFuelUsage = 2;
	const int burnFuelUsage = 1;

	const float resetAfterOOF = 3.0f;
	float resetCountdown = 1.0f;

	bool isObjectiveCompleted = false;

	const float completedTimeout = 3.0f;
	float completedCountdown = 1.0f;

	int remainingFuel = 0;

	public GameObject fuelbar;
	public GameObject outOfFuelText;
	public GameObject player;
	public Canvas deathScreen;
	public Canvas playerControls;
	public Canvas nextLevelScreen;

	private const float deathTimeout = 2.0f;
	float deathTimeoutCounter = 1.0f;

	private bool inRefuelingArea = false;

	// Use this for initialization
	void Start () {
		remainingFuel = startingFuel;
	}
	
	void FixedUpdate () {
		if (inRefuelingArea && remainingFuel < rocketFuelMax) {
			remainingFuel += 1;
		}

		if (CrossPlatformInputManager.GetButton("MainMenu")) SceneManager.LoadScene("MainMenu");

		if (CrossPlatformInputManager.GetButton("FireEngine") || CrossPlatformInputManager.GetButton("BoostEngine")){
			int fuelUsage;

			if (CrossPlatformInputManager.GetButton("BoostEngine")) {
				fuelUsage = boostFuelUsage;
			} else {
				fuelUsage = burnFuelUsage;
			}

			remainingFuel -= fuelUsage;
		}
	}

	void OnGUI(){
		//update fuelbar
		RectTransform fuelbarTransform = fuelbar.GetComponent<RectTransform>();

		if (remainingFuel >= 0) {
			resetCountdown = resetAfterOOF;
			fuelbarTransform.localScale = new Vector3 (((float)remainingFuel / (float)rocketFuelMax), 1f, 1f);
		} else {
			outOfFuelText.GetComponent<CanvasGroup> ().alpha = 1f;

			if (resetCountdown > 0) {
				resetCountdown -= Time.deltaTime/resetAfterOOF;
			} else {
				if (player != null)player.GetComponent<RocketScience> ().killPlayer (); //destroy the player to trigger deathscreen
			}
		}

		if (player == null)
		{
			if (deathTimeoutCounter > 0) {
				deathTimeoutCounter -= Time.deltaTime / deathTimeout;
			} else {
				hide (playerControls);
				show (deathScreen);
			}
		}

		if (isObjectiveCompleted) {
			if (completedCountdown > 0) {
				completedCountdown -= Time.deltaTime/completedTimeout;
			} else {
				hide (playerControls);
				show (nextLevelScreen);
			}
		}
	}

	public void isInRefuelingArea(bool isInArea){
		inRefuelingArea = isInArea;
	}

	public void objectiveCompleted(){
		isObjectiveCompleted = true;
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
