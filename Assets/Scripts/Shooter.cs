using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gunChild;
	private static GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	// Use this for initialization
	void Start () {
		CheckProjectileObject();
		getAnimator();
		setMyLaneSpawner();
	}
	
	// Update is called once per frame
	void Update ()
	{
		animator.SetBool("isAttacking",isAttackerAheadInLane ());
	}

	private void setMyLaneSpawner ()
	{
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> ();

		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}

		Debug.LogError("Unable to find spawner in lane for "+name);
	}

	bool isAttackerAheadInLane ()
	{
		//Exit as False if no children to spawner
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}

		//If attacker is ahead of tower, true
		foreach (Transform child in myLaneSpawner.transform) {
			if (child.transform.position.x >= transform.position.x) {
				return true;
			}
		}

		//All attackers are behind tower, false
		return false;
	}

	private void Fire ()
	{
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gunChild.transform.position;

	}

	private void CheckProjectileObject ()
	{
		projectileParent = GameObject.Find("Projectiles");

		if (!projectileParent) {
			projectileParent = new GameObject ("Projectiles");
		}
	}

	private void getAnimator(){
		animator = gameObject.GetComponent<Animator>();
	}


}
