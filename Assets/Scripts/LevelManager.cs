using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextSceneAfter;
	public bool gotoWinAfterLevel = false;

	// Use this for initialization
	void Start ()
	{
		if (autoLoadNextSceneAfter <= 0) {
			Debug.LogWarning("Attempted to load in negative time");
		} else {
			Invoke ("LoadNextLevel", autoLoadNextSceneAfter);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadLevel (string scenePath)
	{
		SceneManager.LoadScene(scenePath);
	}

	public void QuitApp(){
		Application.Quit();
	}

	public void LoadNextLevel ()
	{
		if(gotoWinAfterLevel)
			SceneManager.LoadScene("Win");
		print("Loading Scene");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
