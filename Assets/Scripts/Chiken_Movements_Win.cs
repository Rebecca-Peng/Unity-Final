using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chiken_Movements_Win : MonoBehaviour {
	
	float speed;
	int dirction;
	int step;
	new Vector3 currentPosition;
	int counter;

	AudioSource cookDoo;

	// Use this for initialization
	void Start () {
		dirction = 1;
		currentPosition = transform.position;
		counter = 0;
		AudioSource[] audios = GetComponents<AudioSource> ();
		cookDoo = audios [0];
	}

	// Update is called once per frame
	void Update () { 
		step+=10;
		if (step >= 180) {
			step = 180;
		}
		transform.rotation = Quaternion.AngleAxis (step, Vector3.up);
		speed += 0.1f * dirction;
		transform.position = new Vector3 (0, speed, 39);
		if (speed >= 2 || speed <= -0.5) {
			dirction *= -1;
		}
		counter++;
		if (counter <= 1) {
			cookDoo.Play ();
		}
	}
}