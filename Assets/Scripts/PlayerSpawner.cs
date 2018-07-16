﻿using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {
	public GameObject playerPrefab;
	GameObject playerInstance;
	// Use this for initialization
	public int numLives = 4;
	float respawnTimer = 1;
	void Start () {
		SpawnPlayer ();
	}

	void SpawnPlayer(){
		numLives--;
		respawnTimer = 1;
		playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
		playerInstance.name = "spaceShip";
	}
	// Update is called once per frame
	void Update () {
		if(playerInstance == null && numLives > 0){
			respawnTimer -= Time.deltaTime;

			if(respawnTimer <= 0){
				SpawnPlayer ();
			}
		}
	
	}

	void OnGUI(){
		if(numLives > 0 || playerInstance != null){
			GUI.Label (new Rect (0, 0, 400, 200), "Lives: " + numLives);
		}else{
			GUI.Label (new Rect (Screen.width/2 - 50, Screen.height/2 - 25, 400, 200), "Game Over");
		}
	}
}
