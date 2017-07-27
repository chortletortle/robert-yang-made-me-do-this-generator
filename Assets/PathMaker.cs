using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathMaker : MonoBehaviour {

	int counter = 0;
	public Transform floorPrefab;
	public Transform pathmakerSpherePrefab;
	public Transform graveTile;
	public Transform gateTile;
	public Transform fenceTile;
	public Transform cam;
	int counterLimit;
	float lowerBound;
	Transform selection;


	void Start () {
		counterLimit = (int)Random.Range (100f, 200f);
		lowerBound = Random.Range (0f, .4f);
	}

	// Update is called once per frame
	void Update () {
		

		if (cam.GetComponent<reset> ().globalTileCount >= 500) {
			Destroy (gameObject);
			return;
		}
		//counter's limit is the life of a pathmaker
		//limiting the amount transform can rotate allows us to generate long corridors
		if (counter < counterLimit) {
			float ranNum = Random.Range (0f, 1f);
			if (ranNum < lowerBound) {
				transform.Rotate (new Vector3 (0f, 90f, 0f));
			} else if (ranNum > lowerBound && ranNum < .70f) {
				transform.Rotate (new Vector3 (0f, -90f, 0f));
			} else if (ranNum > .97f && ranNum < 1.0f) {
				//instantiate pathmakerSpherePrefab
				Instantiate (
					pathmakerSpherePrefab, transform.position, Quaternion.identity
				);
			}
				
			ranNum = Random.Range (0f, 1f);
			if (ranNum < .25) {
				selection = floorPrefab;
			} else if (ranNum > .25 && ranNum < .70f) {
				selection = graveTile;
			} else if (ranNum > .7f && ranNum < .75f) {
				selection = gateTile;
			} else {
				selection = fenceTile;
			}
			transform.position += transform.forward *= 5f;
			transform.position = new Vector3 (Mathf.Round (transform.position.x), 
				Mathf.Round (transform.position.y), Mathf.Round (transform.position.z));
			if (cam.GetComponent<reset> ().tiles.Contains (transform.position)) {
			} else {
				Instantiate (
					selection, transform.position, Quaternion.identity
				);
				cam.GetComponent<reset> ().tiles.Add (transform.position);
				counter++;
				cam.GetComponent<reset> ().globalTileCount++;
			}
		} else {
			Destroy (gameObject);
			//Destroy self
		}
	}
}
