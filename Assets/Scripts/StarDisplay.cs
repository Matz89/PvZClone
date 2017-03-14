using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private static int stars = 100;
	private Text starText;

	public enum Status{
		SUCCESS,
		FAILURE
	};

	// Use this for initialization
	void Start () {
	}

	void Awake(){
		starText = GetComponent<Text>();
		stars = 100;
		updateText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddStars(int amount){
		stars += amount;
		updateText();
	}

	public Status UseStars (int amount)
	{

		if (stars >= amount) {
			stars -= amount;
			updateText();
			return Status.SUCCESS;
		}
		return Status.FAILURE;


	}

	private void updateText(){
		starText.text = stars.ToString();
	}
}
