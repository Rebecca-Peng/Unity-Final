using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinCollider : MonoBehaviour {

	public GameObject explosionPrefab;
	public GameObject wolfToDestory;
	public GameObject winScreen;
	public GameObject restartButton;
	public GameObject chiken;

	// Use this for initialization
	void Start () {
		chiken.GetComponent<Chiken_Movements_Win>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.tag == "Bird") {
			explosionPrefab.SetActive (true);
			Destroy(wolfToDestory);
			StartCoroutine("waitFiveSeconds");
			chiken.GetComponent<Movements>().enabled = false;
			chiken.GetComponent<Chiken_Movements_Win>().enabled = true;
		}


	}

	IEnumerator waitFiveSeconds ()
	{
		yield return new WaitForSeconds(5);
//		print ("four second");
		winScreen.gameObject.SetActive (true); 
		restartButton.gameObject.SetActive (true);
	}
}
