using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMovementScript : MonoBehaviour {

    public GameObject camera;
    public float limitRadius;
    private float moveSpeed;
    public int lives;
    public GameObject panel;
    

	// Use this for initialization
	void Start () {
        limitRadius = 3.4f;
        moveSpeed = 2;
        lives = 1;
    }
	
    void FixedUpdate(){
        float x = gameObject.transform.position.x + moveSpeed * camera.transform.localRotation.y;
        float y = gameObject.transform.position.y - moveSpeed * camera.transform.localRotation.x;

        if( (x*x + y*y) < limitRadius* limitRadius)
        {
            gameObject.transform.position = new Vector3(x, y, 0);
        }else
        {
            gameOver();
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
            gameOver();
        }
    }

    void gameOver()
    {
        moveSpeed = 0;
        panel.GetComponent<Image>().color = new Color(1f, 0f, 0f, 0.5f);
        GameObject.Find("Game Master").SendMessage("onPlayerHit");
        SceneManager.LoadScene("menuScene", LoadSceneMode.Single);
    }

}
