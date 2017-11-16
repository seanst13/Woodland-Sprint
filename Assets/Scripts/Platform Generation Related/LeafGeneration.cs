using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafGeneration : MonoBehaviour {
	
	
	/* The following is based on this source 
	* ggamesplusjames (2015). Unity Endless Runner Tutorial #14 - Random Coin Placement. [video] Available at: https://www.youtube.com/watch?v=mvBWNw8TU1g [Accessed 16 May 2017]..
	*/ 

	public void GenerateLeaves(Vector3 spawnPosition) {

			GameObject leaf = LeafPool.current.GetPooledObject(); 

			if (leaf == null) return; 

			transform.position = spawnPosition;
			leaf.transform.position = transform.position; 
			leaf.transform.rotation = transform.rotation;
			leaf.SetActiveRecursively (true);

		}
	}
