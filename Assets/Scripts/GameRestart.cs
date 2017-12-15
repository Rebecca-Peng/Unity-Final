using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour {

	public Button restart;

	// Use this for initialization
	void Start () {
		restart.onClick.AddListener(reload);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void reload ()
	{
//		Debug.Log("Restart the Game");
		Application.LoadLevel (Application.loadedLevel);
	}
}
