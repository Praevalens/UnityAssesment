using UnityEngine;
using System.Collections;

public class NebulaHandler : MonoBehaviour {
	public GameObject LevelLogicHolder;

	void OnStart(){
	}

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("Entering Nebula");
		if (col.gameObject.name.Equals("Player")) {
			LevelLogicHolder.GetComponent<LevelLogic> ().isInRefuelingArea (true);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		Debug.Log ("Exiting Nebula");
		if (col.gameObject.name.Equals("Player")) {
			LevelLogicHolder.GetComponent<LevelLogic> ().isInRefuelingArea (false);
		}
	}
}
