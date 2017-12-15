using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour {
	Rigidbody rb;
	float speed;
	float run;
	float fly;
	int count;
	int dirct;
	int timer;

	[Range(3,10)]
	public int flyspeed;

	// Use this for initialization
	void Start () {
		rb=GetComponent<Rigidbody> ();
		flyspeed = 4;
	}
	
	// Update is called once per frame
	void Update () {
		float force = (float)this.GetComponent<PlayerSerialRead> ().frequency;
		speed = force;
//		timer++;
//
//		if (timer >= 20) {
//			timer = 0;
//			fly = 0;
//		}
//		if (speed >= 2.5f && speed <= 30.5f) {
//			run = speed/10;
//			fly = 0;
//
//		} else if (speed > 30.5f && speed <= 98.5f) {
//			run = speed / 100;
//			count++;
//			if (run <= 0) {
//				run = 0;
//			}
//				
//
//		} else if (speed > 98.5f) {
//			run = speed/50;
//			if (run <= 0) {
//				run = 0;
//			}
//			count += 5;
//		} 
//			
//		if (count % 15f == 0) {
////			Debug.Log ("____________________Fly____________________");
//			fly = speed/10 + 9.8f;
//		} else {
//			fly = speed / 10f;
//		}
		if (speed >= 171.0f && speed <= 200.0f) {
//			Debug()
			GetComponent<Animator>().Play ("Hen_Walk");
			run = speed / 7.5f;
			fly = 0;
		} else if (speed >= 200.0f) {
			GetComponent<Animator>().Play ("Hen_Run");
			run = speed / 10f;
			fly = speed / flyspeed;	
		} else {
			run = 0;
			fly = 0;
		}
		rb.AddForce (0, fly, run);
//		transform.position = new Vector3(0,speed/5,0);
//		Debug.Log (speed);
	}
}
