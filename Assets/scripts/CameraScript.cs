using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraScript : MonoBehaviour {

	public List<Transform> spawners = new List<Transform>();
	public List<Vector3> spawnerLocs = new List<Vector3> ();

	public Transform spawner;
	Vector3 spawnerLoc;
	// Use this for initialization
	void Start () {
		spawnerLocs.Add(Camera.main.WorldToViewportPoint (spawners[0].transform.position));
	}
	
	// Update is called once per frame
	void Update () {
		if (spawner != null) {
			spawnerLoc = Camera.main.WorldToViewportPoint (spawner.transform.position);
			Debug.Log (spawnerLoc.y);



//			if (spawnerLoc.x > 1 || spawnerLoc.x < -1 || spawnerLoc.z > 1 || spawnerLoc.z < -1) {
//				transform.position = new Vector3(spawner.transform.position.x,transform.position.y,spawner.transform.position.z);
//				transform.position += new Vector3 (0, 10, 0);
//			}

			for (int tileIndex = 0; tileIndex < spawners.Count; tileIndex++) {

				if (spawners [tileIndex] != null) {

					Vector3 currentLoc = Camera.main.WorldToViewportPoint (spawners [tileIndex].transform.position);
			
					if (currentLoc.x < .3f) {
						transform.position += new Vector3 (-5, 0, 0);
						transform.position += new Vector3 (0, 8f, 0);
					}
					if (currentLoc.x > .8f) {
						transform.position += new Vector3 (5, 0, 0);
						transform.position += new Vector3 (0, 8f, 0);
					}

					if (currentLoc.y > .8f) {
						transform.position += new Vector3 (0, 0, 5);
						transform.position += new Vector3 (0, 8f, 0);
					}

					if (currentLoc.y < .3f) {
						transform.position += new Vector3 (0, 0, -5);
						transform.position += new Vector3 (0, 8f, 0);
					}
				}

			}
		}
	}
}
