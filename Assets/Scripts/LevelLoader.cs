using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
	public string sceneName;
	public void OnTriggerEnter2D(Collider2D other){
		SceneManager.LoadScene(sceneName);
	}
}
