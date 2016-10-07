using UnityEngine;
using System.Collections;

public class gameScript : MonoBehaviour {
	public static int nCircles = 10;
	public static int circleDistance = 8;

	public GameObject circleLimitPrefab;
	public float speed;

	private GameObject[] circles = new GameObject[nCircles];

    // Use this for initialization
    void Start () {
		// Instantiate circle limits
		for (int i = 0; i < nCircles; i++) {
			circles[i] = ((GameObject) Instantiate(circleLimitPrefab, new Vector3(0f, 0f, (float) (i * circleDistance)), Quaternion.identity));
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
