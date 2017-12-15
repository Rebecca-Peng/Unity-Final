using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject attackScreen;
	public Text lifeText;
	public int life;

	// Use this for initialization
	void Start () {
		life = 3;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (life <= 0) {
			SceneManager.LoadScene ("GameOver");
		}
	}

	public void wolfAttack (bool WolfIsThere)
	{
		attackScreen.gameObject.SetActive (true); 
		StartCoroutine (wait2second ());

		life -= 1;

		string stringLife = (life).ToString();
		lifeText.text = "" + stringLife;
	}

	IEnumerator wait2second ()
	{
		yield return new WaitForSeconds (2f);
		attackScreen.gameObject.SetActive (false); 
	}
}
