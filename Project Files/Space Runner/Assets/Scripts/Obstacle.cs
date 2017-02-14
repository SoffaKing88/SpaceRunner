using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private HealthSystem hero;

	void Start(){
		hero = GameObject.FindGameObjectWithTag ("Player").GetComponent<HealthSystem> ();
	}

	void OnTriggerStay2D(Collider2D enter) {
		if (!hero.invincible){
			if (enter.CompareTag ("Player")) {
				hero.Knockback (10f, hero.transform.position);
				hero.Damage (1);
			}
		}
	}
}
