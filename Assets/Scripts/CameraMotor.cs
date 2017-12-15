using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {
	
	public Transform target;

	public float smoothSpeed = 0.1f;
	public Vector3 offset;

	void LateUpdate ()
	{
		transform.position = target.position + offset;
	}
}