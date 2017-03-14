﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;
	public float spawnDifficulty = 10f;

	private float difficulty;
	private float difficultyTickCounter;

	// Use this for initialization
	void Start () {
		difficulty = spawnDifficulty;
	}

	// Update is called once per frame
	void Update ()
	{
		foreach (GameObject thisAttacker in attackerPrefabArray) {
			if (isTimeToSpawn (thisAttacker)) {
				Spawn(thisAttacker);
			}
		}
	}

	void Spawn(GameObject myGameObject){
		GameObject myAttacker = Instantiate(myGameObject) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}

	bool isTimeToSpawn (GameObject attackerGameObject)
	{
		Attacker attacker = attackerGameObject.GetComponent<Attacker> ();
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;
		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning ("Spawn rate capped by frame rate");
		}

		float threshold = spawnsPerSecond * Time.deltaTime / difficulty;

		CheckDifficultyIncrease(Time.deltaTime);

		return Random.value < threshold;
	}

	void CheckDifficultyIncrease (float dTime)
	{
		difficultyTickCounter += dTime;

		if (difficultyTickCounter >= 30) {
			IncreaseDifficulty();
			difficultyTickCounter = 0;
		}
	}

	void IncreaseDifficulty(){
		difficulty -= difficulty*0.15f;
		Debug.Log(difficulty + " Difficulty");
	}
}
