using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManagement : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	void Awake(){
		DontDestroyOnLoad(gameObject);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable(){
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnDisable(){
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	void OnLevelFinishedLoading (Scene scene, LoadSceneMode mode)
	{
		AudioClip thisLevelsMusic = levelMusicChangeArray [scene.buildIndex];

		if (thisLevelsMusic) {
			try {
				audioSource.clip = thisLevelsMusic;
				audioSource.loop = true;
				audioSource.Play ();
			} catch {
				Debug.Log("Unable to play music at buildIndex: "+ scene.buildIndex+" and ThisLevelsMusic is :"+thisLevelsMusic);
			}
		}
	}
}
