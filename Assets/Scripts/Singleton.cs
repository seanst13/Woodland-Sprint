using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*This code is based on the below source
* Singleton Unity Spaceshooter Conversion Walkthrough. (2017). [video] Available at: https://www.youtube.com/watch?v=feQxe1HHG-E&feature=youtu.be [Accessed 16 May 2017].
*/

public class Singleton<T> : MonoBehaviour where T: Singleton<T> {
	private static T instance;


	public static T Instance{
		get{ 
			return instance;
		}
	}


	public static bool IsInitialized{
		get{ 
			return instance !=null; 
		}
	}

}
