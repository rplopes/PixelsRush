using UnityEngine;
using System.Collections;

public class CircleLimitScript : MonoBehaviour {
    
	
	void FixedUpdate () {
		float newZ = gameObject.transform.position.z - GameObject.Find ("Game Master").GetComponent<gameScript> ().speed;

		if (newZ < -1) {
			newZ = gameScript.nCircles * gameScript.circleDistance;
		}

		gameObject.transform.position = new Vector3( gameObject.transform.position.x, 
			gameObject.transform.position.y, 
			newZ);
	}
}
