using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeletion : MonoBehaviour {
	
	/* The following code is based on the below source 
	* gamesplusjames (2015). Unity Endless Runner Tutorial #5 Destroying Platforms and adding some random space. [video] Available at: https://www.youtube.com/watch?v=56pUTFSoESE [Accessed 16 May 2017].
	*/
	public GameObject deletionPoint; 

	// Use this for initialization
	void Start () {
		deletionPoint = GameObject.Find ("Deletion Point"); 
	}

	// Update is called once per frame
	void Update () {
		//If the object moves across outside of the screen, set the object in the pools to inactive.
		if (transform.position.x < deletionPoint.transform.position.x) 
			gameObject.SetActive(false); 
		
	}
}
