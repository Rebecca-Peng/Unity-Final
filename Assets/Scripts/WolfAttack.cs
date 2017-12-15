using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAttack : MonoBehaviour {
	public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
//		if (target.GetComponent<OnTriggerAttack> ().caught == true) {
//			Debug.Log ("call attack animation");
//			GetComponent<Animator> ().Play ("Attack");
//		}

		float distance = Vector3.Distance (target.transform.position, transform.position);

		if (distance < 1) {
			GetComponent<Animator> ().Play ("Attack");
		} else {
//			GetComponent<Animator> ().Play ("Walk");
		}
		
	}
}
