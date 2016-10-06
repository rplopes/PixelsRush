using UnityEngine;
using System.Collections;

public class gameScript : MonoBehaviour {

    public GameObject obstaclePrefab;
    [Range(-.01f,.01f)]
    public float obstacleSpeedY;

    private GameObject obstacles;

    // Use this for initialization
    void Start () {
        obstacles =  (GameObject)Instantiate(obstaclePrefab, new Vector3(0f,0f, 5f), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
        obstacles.transform.position = new Vector3( obstacles.transform.position.x, 
                                                    obstacles.transform.position.y - obstacleSpeedY, 
                                                    obstacles.transform.position.z);
	}
}
