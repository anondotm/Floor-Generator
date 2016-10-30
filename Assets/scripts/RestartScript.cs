using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.R)) {
			FloorMaker.tileCount = 0;
			FloorMaker.spawnCounter = 0;
			FloorMaker.innCount = 0;
			FloorMaker.foodCount = 0;
			FloorMaker.residenceCount = 0;
			SceneManager.LoadScene (0);
		}
	}
}
