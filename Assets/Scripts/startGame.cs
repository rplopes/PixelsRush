using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startGame : MonoBehaviour {

    public bool resetScore;

    public GameObject particleLeft, particleRight;
    public float lookTime;
	public int highscore;
    public Text highScoreText;

    bool gaze;
    public AudioSource gazeOnSound1;
    public AudioSource highScoreSound;
    public AudioSource backgroundSound;

    // Use this for initialization
    void Start () {

        if (resetScore)
            PlayerPrefs.SetInt("HighScore", 0);

		highscore = getHighScore ();
        if (getIsNewHighScore())
        {
            if (highscore != 0){
                highScoreSound.Play();
                particleRight.SetActive(true);
                particleLeft.SetActive(true);
            }
            else
                backgroundSound.Play();

            highScoreText.text = "New High Score! \n" + highscore.ToString();
            highScoreText.color = new Color(1, 1, 0, 1);
        }else
        {
            backgroundSound.Play();
            highScoreText.text = "High Score \n" + highscore.ToString();
            highScoreText.color = new Color(0, 1, 0, 1);
        }
        lookTime = 2;
        gaze = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (gaze)
        {
            lookTime -= Time.deltaTime;
        }
        if (lookTime <= 0)
            beginGame();
	}

    void gazeIn()
    {
        gaze = true;
        GetComponent<Renderer>().material.color = Color.green;
        gazeOnSound1.Play();
    }

    void gazeOut()
    {
        gaze = false;
        if(gameObject != null)
            GetComponent<Renderer>().material.color = Color.red;
    }

    void beginGame()
    {
        SceneManager.LoadScene("mainScene", LoadSceneMode.Single);
    }

	int getHighScore() {
		return PlayerPrefs.HasKey ("HighScore") ? PlayerPrefs.GetInt ("HighScore") : 0;
	}

	bool getIsNewHighScore() {
		if (PlayerPrefs.HasKey ("IsNewHighScore")) {
			PlayerPrefs.DeleteKey ("IsNewHighScore");
			return true;
		}
		return false;
	}
}
