using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startGame : MonoBehaviour {

    public GameObject coloring;
    public float lookTime;
	public int highscore;
    public Text highScoreText;

    bool gaze;

	// Use this for initialization
	void Start () {
		highscore = getHighScore ();
        if (getIsNewHighScore())
        {
            highScoreText.text = "New High Score! \n" + highscore.ToString();
            highScoreText.color = new Color(1, 1, 0, 1);
        }else
        {
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
        coloring.gameObject.GetComponent<Light>().color = new Color(0, 1, 0, 1);
    }

    void gazeOut()
    {
        gaze = false;
        if(coloring.gameObject != null)
            coloring.gameObject.GetComponent<Light>().color = new Color(1, 0, 0, 1);
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
