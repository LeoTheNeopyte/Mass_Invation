using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public Transform myTarget;
	public float camaraSpeed = 1.3f;

	
	// Update is called once per frame
	void Update () {
		if (myTarget != null) {
			Vector3 targPos = myTarget.position;
			targPos.z = transform.position.z;

			//gets a delay on the camara fallowing the player
			transform.position = Vector3.Lerp (transform.position, targPos, Time.deltaTime * camaraSpeed);
		}
	}
}
