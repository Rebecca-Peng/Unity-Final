using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(AudioSource))]
public class AttackTheBird : MonoBehaviour {

	public bool WolfIsThere;
	float timer;
	float timeBetweenAttack;
	int counter;
	float startAttackTime;
	float currentTime;
	float deltaTime;

	public GameController gameController;

	AudioSource attackSound;

	// Use this for initialization
	void Start ()
	{
		timeBetweenAttack = 2.0f;
		AudioSource[] audios = GetComponents<AudioSource> ();
		attackSound = audios [0];

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
//		print (timer);
		currentTime = Time.time;

		if (WolfIsThere && timer >= timeBetweenAttack) {
			Attack();
			deltaTime = currentTime - startAttackTime;
		}
		Debug.Log(deltaTime);
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Bird") {
			Debug.Log("Attack");
			WolfIsThere = true;
		}
	}

	void OnCollisionExit (Collision col)
	{
		if (col.gameObject.tag == "Bird") {
			Debug.Log("Attack Over");
			WolfIsThere = false;
		}
	}

	void Attack ()
	{
		timer = 0;
		counter++;
		startAttackTime += Time.deltaTime;
//		GetComponent<Animator>().enabled =true;
//		Debug.Log(1);
		GetComponent<Animator>().Play ("Attack");
//		Debug.Log(2);
		gameController.wolfAttack (WolfIsThere);
		attackSound.Play();
	}
		
}
