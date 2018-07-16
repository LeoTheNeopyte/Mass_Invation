using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	GameObject enemyInstance;
	public GameObject Portal;
	public int NumEnemies;
	int counter = 0;
	int portalCounter = 0;
	public float rateOfspawn = .10f;

	float enemyRate = 5;
	float nextEnemy = 1;
	// Use this for initialization

	void EnemySpawn(){
		Debug.Log ("Enemy Counter" + counter);
		Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 8f, 0);
		enemyInstance = (GameObject)Instantiate (enemyPrefab,position, Quaternion.identity);
		enemyInstance.name = "enemy";
		counter++;
	}
	// Update is called once per frame
	void Update () {
		nextEnemy -= Time.deltaTime;
		if(nextEnemy <= 0){
			nextEnemy = enemyRate;
		
			enemyRate *= 0.1f;
			if(enemyRate < rateOfspawn){
				enemyRate = rateOfspawn;
			}

			if(counter < NumEnemies){
				EnemySpawn ();
			}
			if (enemyInstance == null ) {
				if(portalCounter < 2){
					Instantiate (Portal, new Vector3 (0, 5f, 0), Quaternion.identity);
					portalCounter++;
				}
			}
		}
	}
}
