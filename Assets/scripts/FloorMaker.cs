using UnityEngine;
using System.Collections;

public class FloorMaker : MonoBehaviour {

	public GameObject mainCam;

	public static int innCount;
	public static int foodCount;
	public static int residenceCount;
	public static int shopCount;

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
	public Transform foodPrefab;
	public Transform residencePrefab;
	public Transform drugPrefab;

	public Transform floormakerSpherePrefab;
	// Use this for initialization
	void Start () {
		
		spawnFrequency = Random.Range (0.5f, 1f); //.4 is good
		spawnLifetime = Random.Range (10, 15); //DEFAULT is 10-20

		//FREQUENCY OF TURNING (GREATER IS MORE FREQUENTLY)
		lowerValue = .1f;//DEFAULT is .05
		higherValue = .2f;//DEFAULT is .1


		tileLimit = 100;
	}
	
	// Update is called once per frame
	void Update () {

		if (counter < spawnLifetime && tileCount < tileLimit) {

			whatTile = Random.Range (0, 16); //generates random numbers out of total amount of tiles available
			Transform tileDecide;

			// uses what tile to DECIDE TILE STYLE spawned
			if (whatTile == 0 && innCount < 1) {
				tileDecide = innPrefab;
				innCount++;
			} else if (whatTile == 1 && foodCount < 2) {
				tileDecide = foodPrefab;
				foodCount++;
			} else if (whatTile > 1 && whatTile < 4 && residenceCount < 10) {
				tileDecide = residencePrefab;
				residenceCount++;
			} else if (whatTile > 4 && whatTile < 6 && shopCount < 2) {
				tileDecide = drugPrefab;
				shopCount++;
			}
			else {
				tileDecide = floorPrefab;
			}


			float randFloat = Random.value; //generates a value to determine turning and spawning spawners
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
				Transform newSpawner = Instantiate (floormakerSpherePrefab,this.transform.position,this.transform.rotation)as Transform;
				Camera.main.GetComponent<CameraScript> ().spawners.Add (newSpawner);
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
		//Debug.Log (tileCount);


	}
}
