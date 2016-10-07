using UnityEngine;
using System.Collections;

public class playerMovementScript : MonoBehaviour {

    public GameObject camera;
    public float limitRadius;
    private float moveSpeed;
    public int lives;
    

	// Use this for initialization
	void Start () {
        limitRadius = 3.4f;
        moveSpeed = 2;
        lives = 1;
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

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "obstacle")
        {
            lives--;
            Debug.Log("got hit");
        }
    }

}
