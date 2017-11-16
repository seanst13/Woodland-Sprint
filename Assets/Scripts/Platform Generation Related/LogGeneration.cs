using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	/* The following is based on this source 
	* gamesplusjames (2015). Unity Endless Runner Tutorial #14 - Random Coin Placement. [video] Available at: https://www.youtube.com/watch?v=mvBWNw8TU1g [Accessed 16 May 2017].
	*/ 

public class LogGeneration : MonoBehaviour {
	public void SpawnLog(Vector3 spawnPosition){
		GameObject log = LogPool.current.GetPooledObject (); 

		if (log == null)
			return; 

		transform.position = spawnPosition;
		log.transform.position = transform.position;
		log.transform.rotation = transform.rotation;
		log.SetActive (true); 
	}
}
