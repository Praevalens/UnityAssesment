using UnityEngine;
using System.Collections;

public class Force : MonoBehaviour {
	float rocketForce = 10f;
	float maxForce = 2.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;

		transform.Rotate(0, 0, x);
		Rigidbody2D body = gameObject.GetComponent<Rigidbody2D> ();

		if (Input.GetKey (KeyCode.Space)) {
			Debug.Log ("Current magnitude: " + body.velocity.magnitude);
			if (body.velocity.magnitude < maxForce) {
				body.AddForce (Vector3.up * rocketForce);
			}
		}
	}
}
