using UnityEngine;
using System.Collections;

public class playerMovementScript : MonoBehaviour {

    public GameObject camera;
    public float limitRadius;
    private float moveSpeed;

	// Use this for initialization
	void Start () {
        limitRadius = 3.4f;
        moveSpeed = 2;
    }
	
    void FixedUpdate(){
        float x = gameObject.transform.position.x + moveSpeed * camera.transform.rotation.y;
        float y = gameObject.transform.position.y - moveSpeed * camera.transform.rotation.x;

        if( (x*x + y*y) < limitRadius* limitRadius)
        {
            gameObject.transform.position = new Vector3(x, y, 0);
        }

        /*
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + camera.transform.rotation.y,
                                                    gameObject.transform.position.y - camera.transform.rotation.x,
                                                    0f);
                                                    */
    }
}
