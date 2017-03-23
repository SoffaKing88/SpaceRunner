using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private HealthSystem heroHealth;
	private CharacterMovement heroMove;

	void Start(){
		heroHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<HealthSystem> ();
		heroMove = GameObject.FindGameObjectWithTag ("Player").GetComponent<CharacterMovement> ();
	}

	void OnTriggerStay2D(Collider2D enter) {
		if (!heroHealth.invincible){
			if (enter.CompareTag ("Player")) {
				heroMove.Knockback (10f);
				heroHealth.Damage (1);
			}
		}
	}
}
