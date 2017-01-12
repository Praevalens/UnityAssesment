using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class RocketScience : MonoBehaviour {
	public GameObject PlayerExplosionAnim;

	float rocketMinForce = 15f; //Unable to lift from planets
	float rocketMaxForce = 35f; //Easily lift from planets
	float rocketActualForce = 15f; //Increasing force when no speed is produced

	float maxSpeed = 5f;
	float brakePower = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void FixedUpdate()
	{
		var x = CrossPlatformInputManager.GetAxis ("Horizontal") * Time.deltaTime * 150.0f; //Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;

		Rigidbody2D body = gameObject.GetComponent<Rigidbody2D> ();
		body.angularVelocity = 0f;
		transform.Rotate(0, 0, -x);
			
		if (CrossPlatformInputManager.GetButton("FireEngine") || CrossPlatformInputManager.GetButton("BoostEngine")){
			
			if (CrossPlatformInputManager.GetButton("BoostEngine")) {
				rocketActualForce = rocketMaxForce;
			} else {
				rocketActualForce = rocketMinForce;
			}
		//if (Input.GetKey (KeyCode.Space)) {
			Vector3 curVec = body.velocity;

			Vector3 direction = gameObject.transform.rotation * Vector3.up;
			body.AddForce (direction.normalized * rocketActualForce);

			Vector3 newVec = body.velocity;

			// if the new force makes the rocket go over the speed limit, reverse the force
			if(body.velocity.magnitude > maxSpeed)
			{
				body.velocity = body.velocity.normalized * maxSpeed;
			}
		}

		if (Input.GetKey (KeyCode.C)) {
			// BRAKESSSS
			body.AddForce(-body.velocity.normalized*brakePower);

		}
	}

	void OnCollisionEnter2D(Collision2D col){
		Debug.Log ("collision magnitude: " + col.relativeVelocity.magnitude);
		if (col.relativeVelocity.magnitude > 4.0f) {
			playExplosion ();

			Destroy (gameObject);
		}
	}

	void playExplosion(){
		GameObject explosion = (GameObject)Instantiate (PlayerExplosionAnim);
		explosion.transform.position = transform.position;
		explosion.transform.rotation = transform.rotation;
	}
}
