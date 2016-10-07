using UnityEngine;
using System.Collections;

public class obstacleScript : MonoBehaviour {

	void FixedUpdate () {
		float newZ = gameObject.transform.position.z - GameObject.Find ("Game Master").GetComponent<gameScript> ().speed;

		if (newZ < -1) {
			Destroy (gameObject);

			return;
		}

		gameObject.transform.position = new Vector3( gameObject.transform.position.x, 
			gameObject.transform.position.y, 
			newZ);
	}
}
