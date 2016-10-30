using UnityEngine;
using System.Collections;

public class FloorMaker : MonoBehaviour {
	

	public static int tileCount = 0; //records the TOTAL TILES spawned
	float tileLimit; //limits amount of TILES spawned

	public static int spawnCounter = 0;//records the TOTAL SPAWNERS spawned
	float spawnLifetime; //records TOTAL SPANWERS 

	float spawnFrequency; //if randomValue is MORE than this, then spawn another spawner (more spawners if the number is lower)
	float lowerValue;
	float higherValue;

	int counter = 0;

	int whatTile;
	public Transform floorPrefab;
	public Transform innPrefab;
	public Transform shopPrefab;
	public Transform residencePrefab;

	public Transform floormakerSpherePrefab;
	// Use this for initialization
	void Start () {
		
		spawnFrequency = Random.Range (0.4f, 1f);
		spawnLifetime = Random.Range (10, 20);


		lowerValue = .05f;
		higherValue = .1f;


		tileLimit = 1000;
	}
	
	// Update is called once per frame
	void Update () {

		if (counter < spawnLifetime && tileCount < tileLimit) {
			whatTile = Random.Range (0, 2);
			Transform tileDecide;
			if (whatTile == 0) {
				tileDecide = floorPrefab;
			} else {
				tileDecide = innPrefab;
			}

			float randFloat = Random.value;


			//check if you can turn RIGHT
			if (randFloat < lowerValue) {
				transform.Rotate (new Vector3(0f, 90f, 0f)); 
			} 

			//check if you can turn LEFT
			else if (randFloat >= lowerValue && randFloat <= higherValue) {
				transform.Rotate(new Vector3(0f, -90f, 0f));
			} 

			//check if you can spawn SPAWNERS
			else if (randFloat >= spawnFrequency && spawnCounter<10) {
				//spawn SPAWNER
				Instantiate (floormakerSpherePrefab,this.transform.position,this.transform.rotation);
				spawnCounter++;
			}

			//spawn TILE
			Instantiate (tileDecide,this.transform.position,Quaternion.Euler(0,0,0));

			//move spawner forward, add to counter, add to tile count
			transform.position += transform.forward * 10f;
			counter++;
			tileCount++;


		} else {
			Destroy (this.gameObject);
		}
		Debug.Log (tileCount);


	}
}
