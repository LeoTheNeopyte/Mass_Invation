using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {
	public RectTransform healthTransform;
	private float cachedY;
	private float maxXvalue;
	private float minXvalue;
	private int currenthealth;

	public int maxHealth;
	public Text healthText;
	public Image visualHealth; 
	//public float cooldown;
//	private bool onCD;


	public float invulnPeriod = 0;
	float invulnTimer = 0;
	int correctLayer;

	int CurrentHealth{
		get{ return currenthealth;}
		set{ 
			currenthealth = value;
			Handlehealthbar ();
		}
	}

	// Use this for initialization
	void Start () {
		correctLayer = gameObject.layer;
		cachedY = healthTransform.position.y;
		maxXvalue = healthTransform.position.x;
		minXvalue = healthTransform.position.x - healthTransform.rect.width;
		currenthealth = maxHealth;
	//	onCD = false;
	}

	void OnTriggerEnter2D(){
		currenthealth--;
	
		if (invulnPeriod > 0 /*&& currenthealth > 0*/) {
			invulnTimer = invulnPeriod;
			gameObject.layer = 10;
			//StartCoroutine (CoolDownDmg());
			CurrentHealth -= 1;
				
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (invulnTimer > 0) {
			invulnTimer -= Time.deltaTime;

			if (invulnTimer <= 0) {
				gameObject.layer = correctLayer;

			}
		}
		if (currenthealth <= 0) {
			Die ();
		}
	}
	void Die(){
		DestroyObject (gameObject);
	}


	//IEnumerator CoolDownDmg(){
	//	onCD = true;
	//	yield return new WaitForSeconds (cooldown);
	//	onCD = false;
	//}
	void Handlehealthbar(){
		healthText.text = "Health: " + currenthealth;

		float currentXvalue = MapValues (currenthealth, 0, maxHealth, minXvalue, maxXvalue);

		healthTransform.position = new Vector3 (currentXvalue, cachedY);

		if (currenthealth > maxHealth / 2) {
			visualHealth.color = new Color32 ((byte)MapValues(currenthealth,maxHealth/2,maxHealth,255,0), 255, 0,255);
		} else {
			visualHealth.color = new Color32 (255,(byte)MapValues(currenthealth,0,maxHealth/2,0,255),0,255);
		}
	}


	float MapValues(float x, float inMin, float inMax, float outMin, float outMax){
		return (x- inMin)*(outMax - outMin) / (inMax- inMin) + outMin;
	}
}
