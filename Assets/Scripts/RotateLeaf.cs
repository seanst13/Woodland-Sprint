using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLeaf : MonoBehaviour {

/* The following source was used for inspiration for rotating collectables
 * Unity. (n.d.). Unity - Creating Collectable Objects. [online] Available at: https://unity3d.com/learn/tutorials/projects/2d-ufo-tutorial/creating-collectable-objects [Accessed 16 May 2017].
*/ 

	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate (new Vector3 (0, 0, 45) * Time.deltaTime); 

	}
}
