using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour {

	private LevelManager levelmanager;

	// Use this for initialization
	void Start () {
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		levelmanager.LoadLevel("Start Menu");
	}
}
