using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private HealthSystem heroHealth;

	void Start(){
		heroHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<HealthSystem> ();
	}

	void OnTriggerStay2D(Collider2D enter) {
		if (!heroHealth.invincible){
			if (enter.CompareTag ("Player")) {
				heroHealth.Damage (1);
			}
		}
	}
}
