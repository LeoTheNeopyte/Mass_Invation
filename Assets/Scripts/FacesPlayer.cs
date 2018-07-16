using UnityEngine;
using System.Collections;

public class FacesPlayer : MonoBehaviour {
	public float rotSpeed = 90f;
	public float maxSpeed = 2f;
	Transform player;

	// Update is called once per frame
	void Update () {
		if (player == null) {
			//find the player ship
			GameObject go = GameObject.Find ("spaceShip");
			if (go != null) {
				player = go.transform;
			}
		}
		//this point we've found the player 
		// or it doesnt exist right now
		if (player == null) {
			return; 
		}
		// we have the player for sure and try to face it
		Vector3 dir = player.position - transform.position;
		dir.Normalize ();

		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;
		Quaternion desireRot = Quaternion.Euler (0, 0, zAngle);

		transform.rotation = Quaternion.RotateTowards (transform.rotation, desireRot, rotSpeed * Time.deltaTime);

	}
}
