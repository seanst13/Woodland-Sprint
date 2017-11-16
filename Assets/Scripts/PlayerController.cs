using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	//Global Variable Declaration

	public float jumpHeight; 			//Height at which the player will jump
	public bool touchingPlatform;  		//Checks if the player is touching a platform
	public LayerMask whatIsGround; 		// Used to assign the 'Ground' layer.
	private Rigidbody2D rb2d; 			//Used for the Rigidbody 2D component of the player 
	 

	private Collider2D collider; 		//Used for the Collider2D component of the player
	private bool doubleJump; 			//Used to check if the player can double jump
	private int distanceTravelled;		//Used for measuring the player's movement 

	// Use this for initialization
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		collider = GetComponent<Collider2D> ();
		doubleJump = true; 
	}
		
	void Update()
	{

		if (rb2d.position.y <= -4) {
			Controller.current.SetAlive (false);
		}

		if (Controller.current.CheckIfAlive()) {
			//The following line is for collision detection
			touchingPlatform = Physics2D.IsTouchingLayers (collider, whatIsGround); 

			
/* 
 * The following sources were used for getting player movement and collision detection with the ground, however these have been modified to suit my own needs.
 * gamesplusjames (2015). Unity Endless Runner Tutorial #1 - Player Movement. [video] Available at: https://www.youtube.com/watch?v=GrQalFLtQT4 [Accessed 16 May 2017].
 * gamesplusjames (2015). Unity Endless Runner Tutorial #2 - Finding the Ground. [video] Available at: https://www.youtube.com/watch?v=flGbKSSUY0o [Accessed 16 May 2017].
*/
			
			
			rb2d.velocity = new Vector2 (Controller.current.GetMovementSpeed(), rb2d.velocity.y);
			if (touchingPlatform) {
				doubleJump = true;
			}

			//Code for jumping - this also enables the player to Double Jump
			if (touchingPlatform && ((Input.GetKeyDown (KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.Space))))) {
				rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpHeight);
				doubleJump = true; 
			}

			//Code to check if the player can perform a Double Jump
			if (!touchingPlatform && doubleJump && ((Input.GetKeyDown (KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.Space))))) {
				rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpHeight);
				doubleJump = false; 
			}				

			distanceTravelled = Mathf.RoundToInt (rb2d.position.x);
			Controller.current.SetScore (distanceTravelled); 
			Controller.current.SetMovementSpeed (Controller.current.GetMovementSpeed () + 0.00025f);

		} else { 
			SceneManager.LoadScene ("GameOver");

		}
	}

	
/* The following source was used for inspiration for picking up collectables 
 * Unity. (n.d.). Unity - Creating Collectable Objects. [online] Available at: https://unity3d.com/learn/tutorials/projects/2d-ufo-tutorial/creating-collectable-objects [Accessed 16 May 2017].
*/  
	
	
	//Used for collision detection with collectables and hazzards
	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("Leaf"))
		{			 
			Controller.current.SetLeaves (); 
			other.gameObject.SetActive (false); 

		} 
		else if (other.gameObject.CompareTag ("Hazzard"))
		{
			Controller.current.updateHealth (-1); 
			other.gameObject.SetActive (false); 
		}

	}
		
}
