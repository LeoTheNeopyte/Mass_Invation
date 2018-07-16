using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {
	public Vector3 bulletOffset = new Vector3 (0, 0.5f, 0);

	Transform player;

	public GameObject bulletPreFab;

	public float fireDelay = 0.50f;

	float cooldowntimer = 0;
	int bulletLayer;

	void Start(){
		bulletLayer = gameObject.layer;
	}
	// Update is called once per frame
	void Update () {

		if (player == null) {
			//find the player ship
			GameObject go = GameObject.Find ("spaceShip");
			if (go != null) {
				player = go.transform;
			}
		}

		cooldowntimer -= Time.deltaTime;

		if( cooldowntimer <=0 && player != null && Vector3.Distance(transform.position , player.position) < 10 ){
			//shoot

			Debug.Log("Pew!");
			cooldowntimer = fireDelay;

			Vector3 offset = transform.rotation * bulletOffset;

			//changes the layer of the bullet depending on who is shooting it
			GameObject bulletGO = (GameObject)Instantiate (bulletPreFab, transform.position + offset, transform.rotation);
			bulletGO.layer = bulletLayer;
		}
	}
}
