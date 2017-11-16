using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The following is based on the below source 
 * Unity (2014). Live Training 7 Apr 2014 - Object Pooling. [image] Available at: https://www.youtube.com/watch?v=9-zDOJllPZ8 [Accessed 16 May 2017].
 */ 


public class LogPool : MonoBehaviour {
	public static LogPool current; 
	public GameObject pooledObject;
	public int pooledAmount;
	public bool willGrow = true;

	List<GameObject> pooledObjects;

	void Awake(){
		current = this; 
	}

	// Use this for initialization
	void Start () {
		pooledObjects = new List<GameObject> (); 
		for(int i = 0; i < pooledAmount; i++){
			GameObject obj = (GameObject)Instantiate(pooledObject);
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}
	}

	public GameObject GetPooledObject()
	{
		for (int i = 0; i < pooledObjects.Count; i++) {
			if (!pooledObjects [i].activeInHierarchy)
				return pooledObjects [i];
		}
		if (willGrow)
		{
			GameObject obj = (GameObject)Instantiate(pooledObject);
			pooledObjects.Add(obj);
			return obj; 
		}
		return null; 
	}
}
