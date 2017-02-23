using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {


	private MusicManagement musicManager;
	// Use this for initialization
	void Start ()
	{
		musicManager = GameObject.FindObjectOfType<MusicManagement> ();

		if (musicManager) {
			Debug.Log ("Found Music Manager " + musicManager);
		} else {
			Debug.LogWarning("No music manager found in Start scene, cannot set volume");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
