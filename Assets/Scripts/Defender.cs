using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

	private StarDisplay starDisplay;

	public int starCost = 100;
	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(){
	}

	public void AddStars(int numStars){
		starDisplay.AddStars(numStars);
	}
}
