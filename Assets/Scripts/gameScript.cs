using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameScript : MonoBehaviour {

    public bool playing;

	public static int nCircles = 10;
	public static int circleDistance = 8;

	private static int spawnDistance = gameScript.nCircles * gameScript.circleDistance;
	private static float gameOverTimeout = 2.5f;
	private static float difficultyAdjustmentTimeout = 4.0f;

	public GameObject circleLimitPrefab;
	public GameObject deathStarPrefab;
	public GameObject bowserPrefab;
	public float speed;
	private float spawnRate;

    public Text timeText;

	private GameObject[] circles = new GameObject[nCircles];
    
    // Use this for initialization
    void Start () {
		Invoke("SpawnObstacle", spawnRate);
		Invoke("AdjustDifficulty", difficultyAdjustmentTimeout);
        playing = true;
		speed = 0.5f;
		spawnRate = 0.9f;
        // Instantiate circle limits
        for (int i = 0; i < nCircles; i++) {
			circles[i] = ((GameObject) Instantiate(circleLimitPrefab, new Vector3(0f, 0f, (float) (i * circleDistance)), Quaternion.identity));
		}
	}
	


    void SpawnObstacle() {
        double r = Random.value;
        
        if (r < 0.5) {
            Instantiate(deathStarPrefab, new Vector3(Random.insideUnitCircle.x * 2.2f, Random.insideUnitCircle.y * 2.2f, spawnDistance), Quaternion.identity);
        } else {
            Instantiate(bowserPrefab, new Vector3(Random.insideUnitCircle.x * 2f, Random.insideUnitCircle.y * 2f, spawnDistance), Quaternion.identity);
        }

        Invoke("SpawnObstacle", spawnRate);
    }

	void AdjustDifficulty() {
		if (speed == 0)
			return;

		speed += 0.05f;
		if (spawnRate > 0.4f && (speed == 0.6f || speed == 0.7f || speed >= 0.8f)) {
			spawnRate -= 0.1f;
		}
		Invoke("AdjustDifficulty", difficultyAdjustmentTimeout);
	}

	// Update is called once per frame
	void Update () {
        if(playing)
            timeText.text = ((int)Time.timeSinceLevelLoad).ToString();

	}

    void FixedUpdate()
    {
    }

	void onPlayerHit(int newScore)
    {
        speed = 0;
        playing = false;

		if ((PlayerPrefs.HasKey ("HighScore") && PlayerPrefs.GetInt ("HighScore") < newScore)
			|| !PlayerPrefs.HasKey ("HighScore")) {
			PlayerPrefs.SetInt ("HighScore", newScore);
			PlayerPrefs.SetInt ("IsNewHighScore", 1);
		}
		Invoke("backToMenuScene", gameOverTimeout);
	}

	void backToMenuScene() {
		SceneManager.LoadScene("menuScene", LoadSceneMode.Single);
	}

}
