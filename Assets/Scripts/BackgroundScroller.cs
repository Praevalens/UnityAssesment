using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

	// Use this for initialization
	public GameObject playerModel;
	public float scaleFactor = 0.1f;

	void Start () {
	
	}

	void Update(){
		float xSpeed = playerModel.transform.position.x;
		float ySpeed = playerModel.transform.position.y;
		//Debug.Log("Xs: " + xSpeed + ", Ys: " + ySpeed);

		xSpeed = xSpeed * scaleFactor * scaleFactor;
		ySpeed = ySpeed * scaleFactor * scaleFactor;

		Vector2 offset = new Vector2();
		offset.x += xSpeed;
		offset.y += ySpeed;
		gameObject.GetComponent<Renderer> ().material.mainTextureOffset = offset;
		//Debug.Log("X: " + offset.x + ", Y: " + offset.y);
	}
}
