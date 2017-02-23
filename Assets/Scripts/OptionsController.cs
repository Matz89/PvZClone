using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelmanager;

	private MusicManagement musicManagement;

	// Use this for initialization
	void Start () {
		musicManagement = GameObject.FindObjectOfType<MusicManagement>();

		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
		musicManagement.ChangeVolume(volumeSlider.value);
	}

	public void SaveAndExit ()
	{
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(difficultySlider.value);
		levelmanager.LoadLevel("Start Menu");
	}

	public void SetDefaults ()
	{
		volumeSlider.value = 0.8f;
		difficultySlider.value = 2f;
	}

}
