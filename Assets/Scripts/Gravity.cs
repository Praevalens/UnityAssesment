using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
	//float maxGravDistance = 4.0f;
	//float maxGravity = 35.0f;
	float G = 6.674f*Mathf.Pow(10f,-11f);
	public float gravityForceModifier;

	GameObject[] gravityObjects;

	// Use this for initialization
	void Start () {
		gravityObjects = GameObject.FindGameObjectsWithTag("gravityObject");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		foreach (GameObject gravityObject in gravityObjects) {
			float dist = Vector3.Distance(gravityObject.transform.position, transform.position);

			// Do the Force calculation
			// Use numbers to adjust force, distance will be changing over time!
			float forcePlanet = G * (10f * Mathf.Pow(10f, 11f)*gravityForceModifier)/Mathf.Pow(dist,2f);

			Collider2D planetBody = gameObject.GetComponent<Collider2D> ();
			Rigidbody2D shipBody = gravityObject.GetComponent<Rigidbody2D> ();

			// Find the Normal direction
			Vector3 normalDirectionPlanet = (planetBody.transform.position - shipBody.transform.position).normalized;

			// calculate the force on the object from the planet
			Vector3 normalForcePlanet = normalDirectionPlanet * forcePlanet;

			shipBody.AddForce(normalForcePlanet);

			// .... add forces of other objects. 
		}


	}


}