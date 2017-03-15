using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float levelSeconds = 90;

	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winLabel;

	// Use this for initialization
	void Start ()
	{
		slider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		FindYouWin();
		winLabel.SetActive(false);

	}

	void FindYouWin ()
	{
		winLabel = GameObject.Find ("WIN");
		if (!winLabel) {
			Debug.LogWarning("Please create WIN object");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		slider.value = Time.timeSinceLevelLoad / levelSeconds;

		if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel) {
			HandleWinCondition();

		}
	}

	void HandleWinCondition(){
		DestroyAllObjectsWithTag("destroyOnWin");
		isEndOfLevel = true;
		audioSource.Play();
		Invoke("LoadNextLevel",audioSource.clip.length);
		winLabel.SetActive(true);
	}

	private void DestroyAllObjectsWithTag (string _tag)
	{
		GameObject[] go_array = GameObject.FindGameObjectsWithTag (_tag);
		foreach (GameObject go in go_array) {
			Destroy(go);
		}
	}

	void LoadNextLevel(){
		levelManager.LoadNextLevel();
	}
}
