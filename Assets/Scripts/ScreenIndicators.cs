using UnityEngine;
using System.Collections;
using GUIDrawing;

public class ScreenIndicators : MonoBehaviour {
	public GameObject player;
	public GameObject[] indicatables;

	Camera cameraObject;

	//GameObject[] indicatables;
	int layerMask = 1 << 8;
	ArrayList points = new ArrayList();

	// Use this for initialization
	void Start () {
		//indicatables = GameObject.FindGameObjectsWithTag("BlackHole");
		cameraObject = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		//empty the list
		points = new ArrayList ();

		foreach (GameObject indicatable in indicatables){
			Vector2 directionvector = new Vector2(indicatable.transform.position.x-player.transform.position.x, indicatable.transform.position.y-player.transform.position.y);

			RaycastHit2D hit = Physics2D.Raycast (player.transform.position, directionvector, Mathf.Infinity, layerMask);
			Debug.DrawRay (player.transform.position, directionvector, Color.red, 0.1f,false);

			if (hit != null) {
				points.Add (hit);
			}
		}

	}


	private void OnGUI() {
		foreach (RaycastHit2D hit in points) {
			Vector3 position = cameraObject.WorldToScreenPoint (hit.point);
			Vector3 playerposition = cameraObject.WorldToScreenPoint (player.transform.position);

			GUI.Label(new Rect(position.x,-position.y*2, 100, 50), "<color=white><size=40>BLACK HOLE</size></color>", GUIStyle.none);
			//GUI.Label(new Rect(hit.point.x-48,hit.point.y-23, 100, 50), "<color=white><size=40>BLACK HOLE</size></color>", GUIStyle.none);
			Drawing.DrawLine(playerposition, new Vector3(position.x,-position.y*2,position.z), Color.cyan, 1f);
			Debug.DrawLine (playerposition, position, Color.magenta, 1f);
		}
	}
}
