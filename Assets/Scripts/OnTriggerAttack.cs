using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerAttack : MonoBehaviour {
public bool caught;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

//	void OnTriggerEnter (Collider other)
//	{
//		if (other.gameObject.tag == "Wolf") {
//			Debug.Log ("Attack");
//		}
//	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Wolf") {
//			Debug.Log ("Attack2");
			caught = true;
		}
	}

	void OnCollisionExit (Collision other)
	{
		if (other.gameObject.tag == "Wolf") {
			Debug.Log ("Finish");
		}
	}
}
