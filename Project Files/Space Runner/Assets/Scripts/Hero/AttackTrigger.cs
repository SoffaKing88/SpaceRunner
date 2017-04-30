using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

	private HealthSystem enemy;

	public int dmg = 1;

	// Finds the collider from whatever GameObject this hits, sees if it's an enemy and then does damage to it.
	void OnTriggerEnter2D(Collider2D col){
		if (col.isTrigger != true && col.CompareTag ("Enemy")) {
			enemy = col.gameObject.GetComponent<HealthSystem>();
			enemy.Damage(dmg);
		}
	}
}
