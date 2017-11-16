using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;


/*This code uses the Singleton design pattern adapted from the below source
* Singleton Unity Spaceshooter Conversion Walkthrough. (2017). [video] Available at: https://www.youtube.com/watch?v=feQxe1HHG-E&feature=youtu.be [Accessed 16 May 2017].
*/
public class Controller : Singleton<Controller> {

	public static Controller current; 

	public float movementSpeed;
	public Text scoreText;
	public Text leafText;
	public Text healthText; 

	private int playerHealth; 
	private int score;
	private bool alive;
	private int leavesCollected; 


	void Awake(){
		current = this; 
	}

	// Use this for initialization
	void Start () {


		score = 0;
		leavesCollected = 0;
		playerHealth = 5;
		alive = true; 
		
	}
	
	// Update is called once per frame
	void Update () {

		scoreText.text = "Score: " + GetScore ().ToString ();
		healthText.text = GetHealth().ToString ();
		leafText.text = "Leaves:" + GetLeavesCollected ().ToString(); 
		
	}

	public void updateHealth(int value){
		playerHealth = playerHealth + value; 

		if (playerHealth == 0)
			SetAlive (false); 
	}

	public void SetMovementSpeed(float speed){
		movementSpeed = speed; 
		
	}

	public float GetMovementSpeed(){
		return this.movementSpeed; 
	}

	public void SetScore(int distanceTravelled){

	score = distanceTravelled + (leavesCollected * 5);
		
	}

	public int GetScore(){
		return this.score;
	}

	public int GetHealth(){

		return this.playerHealth; 
	}

	public bool CheckIfAlive(){
		return alive; 
	}

	public void SetAlive(bool status){
		alive = status; 
	}

	public int GetLeavesCollected(){
		return this.leavesCollected; 
	}

	public void SetLeaves (){
		leavesCollected = leavesCollected + 1;
		leafText.text = "Leaves: " + leavesCollected.ToString(); 

		if (leavesCollected % 100 == 0)
			updateHealth (1); 

		SetMovementSpeed(movementSpeed + 0.0045f);

		}



	public void LoadGame(){

		SceneManager.LoadScene ("Main Game");

	}

	public void LoadInstructions(){
		SceneManager.LoadScene ("Instructions");	
	}


	public void LoadMenu(){
		SceneManager.LoadScene ("Main Menu");
	}


	public void ExitGame(){

		Application.Quit (); 

	}

	}		

