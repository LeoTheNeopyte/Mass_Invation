﻿using UnityEngine;
using System.Collections;

public class QuitAplication : MonoBehaviour {

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)== true){
			Application.Quit ();
		}
	}
}
