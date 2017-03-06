using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class fox : MonoBehaviour {

	private Attacker attacker;
	private Animator anim;
	// Use this for initialization
	void Start () {
		attacker = gameObject.GetComponent<Attacker> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D collider){
		GameObject obj = collider.gameObject;
		if (!obj.GetComponent<Defender> ()) {
			return;
		}
		if (obj.GetComponent<Stone> ()) {
			anim.SetTrigger ("jumpTrigger");
		} else {
			anim.SetBool ("isAttacking", true);
			attacker.Attack (obj);
		}
	}
}
