using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

	public float maxSpeed = -2f;
	// Update is called once per frame
	void Update () {

		//transform.Translate(transform.forward * maxSpeed * Time.smoothDeltaTime);

		Vector3 pos = transform.position;

		Vector3 velocity = new Vector3 (0, maxSpeed * Time.deltaTime, 0);
	    pos += velocity;

		transform.position = pos;
	}
}
