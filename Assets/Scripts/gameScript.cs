using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameScript : MonoBehaviour {

    public bool playing;

	public static int nCircles = 10;
	public static int circleDistance = 8;
	public static float spawnRate = 0.9f;

	private static int spawnDistance = gameScript.nCircles * gameScript.circleDistance;
	private static float gameOverTimeout = 2.5f;

	public GameObject circleLimitPrefab;
	public GameObject deathStarPrefab;
	public GameObject bowserPrefab;
	public float speed;

    public Text timeText;

	private GameObject[] circles = new GameObject[nCircles];
    
    // Use this for initialization
    void Start () {
		Invoke("SpawnObstacle", spawnRate);
        playing = true;
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
