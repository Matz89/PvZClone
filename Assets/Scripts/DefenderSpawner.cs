using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	private GameObject parent;

	private StarDisplay starDisplay;

	// Use this for initialization
	void Start ()
	{
		parent = GameObject.Find ("Defenders");
		if (!parent) {
			parent = new GameObject("Defenders");
		}

		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown ()
	{

		if (starDisplay.UseStars (DefenderCost ()) == StarDisplay.Status.SUCCESS) {
			SpawnDefender ();
		} else {
			Debug.Log("Insufficient stars to spawn.");
		}

	}

	int DefenderCost(){
		return Button.selectedDefender.GetComponent<Defender>().starCost;
	}

	void SpawnDefender ()
	{
		GameObject defender = Instantiate(
								Button.selectedDefender, 
								CalculateWorldPointOfMouseClick(), 
								Quaternion.identity);
		defender.transform.parent = parent.transform;
	}

	Vector2 CalculateWorldPointOfMouseClick(){
		Vector3 ans = new Vector3();
		ans = myCamera.ScreenToWorldPoint(Input.mousePosition);

		return SnapToGrid(ans);
	}

	Vector2 SnapToGrid (Vector3 rawWorldPos)
	{
		Vector2 ans = new Vector2(Mathf.RoundToInt(rawWorldPos.x), Mathf.RoundToInt(rawWorldPos.y));

		return ans;
	}
}
