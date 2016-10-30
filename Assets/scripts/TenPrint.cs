using UnityEngine;
using System.Collections;

public class TenPrint : MonoBehaviour {

	public Transform prefabA, prefabB;

	// Use this for initialization
	void Start () {
		for (int y = 0; y < 20; y++) { // the "vertical" axis of our grid
			for (int x = 0; x < 20; x++) { // the "horizontal" axis of our grid
				//code one instance of the loop and get that working
				//that means: randomly spawn either prefabA or prefabB
				if (Random.value > 0.5f) {
					Instantiate (prefabA, new Vector3 (x * 5f, 0f, y * 5), Quaternion.Euler (0f, 45f, 0f));
				} else {
					Instantiate (prefabB, new Vector3 (x * 5f, 0f, y * 5), Quaternion.Euler (0f, 45f, 0f));
				}
			}
		}

	}

}
