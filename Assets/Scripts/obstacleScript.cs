using UnityEngine;
using System.Collections;

public class obstacleScript : MonoBehaviour {

    public GameObject sprite;

    void Start()
    {
        sprite.transform.position = new Vector3(sprite.transform.position.x, sprite.transform.position.y,80f);
    }

	void FixedUpdate () {
		float newZ = sprite.transform.position.z - GameObject.Find ("Game Master").GetComponent<gameScript> ().speed;

        if (newZ < -1)
        {
            Destroy(gameObject);
            return;
        }

        if (newZ < 1) {
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
		}

        sprite.transform.position = new Vector3( gameObject.transform.position.x, 
			gameObject.transform.position.y, 
			newZ);
	}
}
