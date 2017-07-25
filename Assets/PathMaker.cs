using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMaker : MonoBehaviour {

	public static int globalTileCount = 0;

	int counter = 0;
	public Transform floorPrefab;
	public Transform pathmakerSpherePrefab;
	int counterLimit;
	float lowerBound;

	void Start () {
		counterLimit = (int)Random.Range (100f, 200f);
		lowerBound = Random.Range (0f, .7f);
	}

	// Update is called once per frame
	void Update () {
		if (globalTileCount >= 1000) {
			Destroy (gameObject);
			return;
		}
		//counter's limit is the life of a pathmaker
		//limiting the amount transform can rotate allows us to generate long corridors
		//
		if (counter < counterLimit) {
			float ranNum = Random.Range (0f, 1f);
			if (ranNum < lowerBound) {
				transform.Rotate (new Vector3 (0f, 90f, 0f));
			} else if (ranNum > lowerBound && ranNum < .70f) {
				transform.Rotate (new Vector3 (0f, -90f, 0f));
			} else if (ranNum > .95f && ranNum < 1.0f) {
				//instantiate pathmakerSpherePrefab
				Instantiate (
					pathmakerSpherePrefab, transform.position, Quaternion.identity
				);
			}
			Instantiate (
				floorPrefab, transform.position, Quaternion.identity
			);
			transform.position += transform.forward *= counterSpeed;
			counter++;
			globalTileCount++;

		} else {
			Destroy (gameObject);
			//Destroy self
		}
	}
}
