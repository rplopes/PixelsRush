using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerMovementScript : MonoBehaviour {

    public GameObject camera;
    public float limitRadius;
    private float moveSpeed;
	private bool alive;

    public GameObject panel;
    public float timePlaying;

    public AudioSource loseSound;

	// Use this for initialization
	void Start () {
        timePlaying = -1;
        limitRadius = 3.4f;
        moveSpeed = 0;
		alive = true;

        gameObject.transform.position = new Vector3(0f, 0f, 0f);

    }

    void Update()
    {
		if (alive) {
			if (timePlaying >= 0)
				moveSpeed = 1;
			timePlaying += Time.deltaTime;
		}
    }
	
    void FixedUpdate(){
		if (alive) {
			float x = gameObject.transform.position.x + moveSpeed * camera.transform.localRotation.y;
			float y = gameObject.transform.position.y - moveSpeed * camera.transform.localRotation.x;

			if ((x * x + y * y) < limitRadius * limitRadius) {
				gameObject.transform.position = new Vector3 (x, y, 0);
			} else {
				gameOver ();
			}
		}
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
        loseSound.Play();
		alive = false;
        panel.GetComponent<Image>().color = new Color(1f, 0f, 0f, 0.5f);
		GameObject.Find("Game Master").SendMessage("onPlayerHit", (int) timePlaying + 1);
    }

}
