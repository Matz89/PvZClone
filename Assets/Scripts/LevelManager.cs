using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextSceneAfter;

	// Use this for initialization
	void Start () {
		if(autoLoadNextSceneAfter != 0)
			Invoke("LoadNextLevel",autoLoadNextSceneAfter);
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
		print("Loading Scene");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
