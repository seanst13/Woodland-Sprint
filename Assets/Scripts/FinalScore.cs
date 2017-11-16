using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	public Text scoreText;
	public Text leafText;

	// Use this for initialization
	void Start () {

		scoreText.text = "";
		leafText.text = ""; 


	}

	void Update(){

		if (Controller.current.GetScore() != 0) {
		
			scoreText.text = "Final Score: " + Controller.current.GetScore ().ToString ();
			leafText.text = "Leaves Collected: " + Controller.current.GetLeavesCollected ().ToString (); 
		}

	}

}
