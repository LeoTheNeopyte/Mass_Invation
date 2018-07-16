using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
	public float spawn = 1.5f;
	public GameObject bulletPreFab;

	int bulletLayer;

	public float fireDelay = 0.25f;
	float cooldowntimer = 0;

	void Start(){
		bulletLayer = gameObject.layer;
	}
	// Update is called once per frame
	void Update () {
		cooldowntimer -= Time.deltaTime;

		if(Input.GetButton("Fire1") && cooldowntimer <=0 ){
			//shoot

			//Debug.Log("Pew!");
			cooldowntimer = fireDelay;

			Vector3 offset = new Vector3 (0, spawn, 0);

			GameObject bulletGO = (GameObject)Instantiate (bulletPreFab, transform.position + offset, transform.rotation);
			bulletGO.layer = bulletLayer;
		}
	}
}
