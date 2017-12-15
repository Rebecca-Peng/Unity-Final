using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMovement : MonoBehaviour {
	public float speed = 1f;
	public Transform bird;
	Animator m_Animator;
	public GameObject target;
	public float walkspeed;


	// Use this for initialization
	void Start () {
		m_Animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * speed);
		transform.LookAt(bird.transform.position);
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y,0);
		float distance = Vector3.Distance(target.transform.position,transform.position);
//		walkspeed = 4/distance ;
//		speed = walkspeed;
//		Debug.Log (speed);
		speed = 2f;
		m_Animator.speed = walkspeed;
		hit();
	}

	void hit ()
	{
		if (GetComponent<AttackTheBird> ().WolfIsThere) {
			walkspeed = 0;
			speed = 0;
//			m_Animator.enabled = false;
//			Debug.Log("hit");
		}

	}
}
//public AnimationCrve = AnimationCrve liner(0,0,1,1)