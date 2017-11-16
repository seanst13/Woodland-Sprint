using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour {

	public GameObject platform; 
	public Transform pointToGenerate;
	public float platformdistance;
	private float minHeight;
	private float maxHeight;
	private float platformHeight;
	private float platformwidth;

	private LeafGeneration leafGenerator;
	private LogGeneration logGenerator; 

	private int logFrequency;
	private int leafFrequency; 
	
	
	/* The following code is based on the below sources, however the code has been modified to suit my needs
	* gamesplusjames (2015). Unity Endless Runner Tutorial #4 - Generating Infinite Platforms. [video] Available at: https://www.youtube.com/watch?v=yiXlPP8jOvs [Accessed 16 May 2017].
	* gamesplusjames (2015). Unity Endless Runner Tutorial #14 - Random Coin Placement. [video] Available at: https://www.youtube.com/watch?v=mvBWNw8TU1g [Accessed 16 May 2017].
	* Unity (2014). Live Training 7 Apr 2014 - Object Pooling. [image] Available at: https://www.youtube.com/watch?v=9-zDOJllPZ8 [Accessed 16 May 2017].
	*/
	

	// Use this for initialization
	void Start () {
		platformwidth = platform.GetComponent<BoxCollider2D> ().size.x;
		minHeight = -2;
		maxHeight = 3;

		leafGenerator = FindObjectOfType<LeafGeneration>(); 
		logGenerator = FindObjectOfType<LogGeneration> ();
		logFrequency = 80;
		leafFrequency = 25; 
	}
	
	// Update is called once per frame
	void Update () {

		heightCheck ();

		if (transform.position.x < pointToGenerate.position.x) {
			GameObject obj = ObjectPool.current.GetPooledObject(); 

			if (obj == null) return; 

			obj.transform.position = transform.position; 
			obj.transform.rotation = transform.rotation;
			obj.SetActive (true); 


			if (Random.Range (0, 100) > leafFrequency) {
				leafGenerator.GenerateLeaves (new Vector3 ((transform.position.x + 5f), transform.position.y + 1f, transform.position.z)); 
			}

			if (Random.Range (0, 100) > logFrequency) {
				logGenerator.SpawnLog (new Vector3 ((transform.position.x + Random.Range (-5, 5)), transform.position.y + 0.9f, transform.position.z));
			}
			transform.position = new Vector3 (transform.position.x + platformdistance
				+ platformwidth + Random.Range(-1,5),
				platformHeight, transform.position.z);
		}			

	}
	void heightCheck(){
		
		platformHeight = Random.Range (minHeight, maxHeight);
		if (platformHeight + transform.position.y < minHeight) 
		{
			platformHeight = minHeight;
		} 
		else if (platformHeight + transform.position.y > maxHeight) 
		{
			platformHeight = maxHeight; 
		}
	}
}
