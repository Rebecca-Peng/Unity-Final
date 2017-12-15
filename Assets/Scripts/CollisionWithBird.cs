using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithBird : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Bird") {
			Debug.Log ("Attack");
		}
	}

	void onCollisionExit (Collision col)
	{
		if (col.gameObject.tag == "Bird") {
			Debug.Log ("Game Over");
		}
	}

	void Attack ()
	{
		
	}
}
