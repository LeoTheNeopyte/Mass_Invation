using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float maxSpeed = 3.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//public float shipBoundaries = 0.5f;
		// Use this for initialization
	
		// Update is called once per frame
	

			Vector3 posX = transform.position;
			posX.x += maxSpeed * Time.deltaTime * Input.GetAxis("Horizontal");

			float ScreenRatio = (float)Screen.width / (float)Screen.height;
			float withortho = Camera.main.orthographicSize * ScreenRatio;

		if(posX.x > withortho){
			posX.x = withortho;
		}
		if(posX.x < -withortho){
			posX.x = -withortho;
		}

		transform.position = posX;

			//move the space ship verical 
			Vector3 posY = transform.position;
			//if key not pressed input.getaxis is 0
			posY.y += maxSpeed * Time.deltaTime * Input.GetAxis("Vertical");

			//restrict player to the camara boundaries
			if(posY.y > Camera.main.orthographicSize){
				posY.y = Camera.main.orthographicSize;
			}
			if(posY.y < -Camera.main.orthographicSize){
				posY.y = -Camera.main.orthographicSize;
			}

			transform.position = posY;



	}
}
