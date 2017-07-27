using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour {

	public Transform sphere;
	public int globalTileCount = 0;
	public ArrayList tiles = new ArrayList();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
			globalTileCount = 0;
			tiles = new ArrayList();
		}
	}
}
