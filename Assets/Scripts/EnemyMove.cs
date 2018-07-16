using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	public float maxSpeed = -2f;
	// Update is called once per frame
	void Update () {

		transform.Translate(transform.up * maxSpeed * Time.smoothDeltaTime);


	}
}
