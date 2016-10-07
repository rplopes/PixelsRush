﻿using UnityEngine;
using System.Collections;

public class gameScript : MonoBehaviour {
	public static int nCircles = 10;
	public static int circleDistance = 8;
	public static float spawnRate = 0.9f;

	private static int spawnDistance = gameScript.nCircles * gameScript.circleDistance;

	public GameObject circleLimitPrefab;
	public GameObject deathStarPrefab;
	public GameObject bowserPrefab;
	public float speed;

	private GameObject[] circles = new GameObject[nCircles];

    // Use this for initialization
    void Start () {
		Invoke("SpawnObstacle", spawnRate);

		// Instantiate circle limits
		for (int i = 0; i < nCircles; i++) {
			circles[i] = ((GameObject) Instantiate(circleLimitPrefab, new Vector3(0f, 0f, (float) (i * circleDistance)), Quaternion.identity));
		}
	}
	
	void SpawnObstacle () {
		double r = Random.value;

		if (r < 0.5) {
			Instantiate (deathStarPrefab, new Vector3 (Random.insideUnitCircle.x * 2.2f, Random.insideUnitCircle.y * 2.2f, spawnDistance), Quaternion.identity);
		} else {
			Instantiate (bowserPrefab, new Vector3 (Random.insideUnitCircle.x * 2f, Random.insideUnitCircle.y * 2f, spawnDistance), Quaternion.identity);
		}

		Invoke("SpawnObstacle", spawnRate);
	}
}
