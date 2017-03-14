using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	private bool attacking = false;

	private float attackTimer = 0f;
	private float attackCD = 0.3f;

	public Collider2D attackTrigger;

	void Awake() {
		// Make sure collider isn't automatically on and hitting things
		attackTrigger.enabled = false;
	}

	void Update() {
		// Attack as long as you aren't already in the middle of an attack
		if (Input.GetKeyDown ("c") && !attacking) {
			attacking = true;
			attackTimer = attackCD;

			attackTrigger.enabled = true;
		}

		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
				attackTrigger.enabled = false;
			}
		}
	}
}
