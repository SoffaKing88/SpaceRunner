using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

	private HealthSystem enemy;

	public int dmg = 1;

	void OnTriggerEnter2D(Collider2D col){
		if (col.isTrigger != true && col.CompareTag ("Enemy")) {
			enemy = col.gameObject.GetComponent<HealthSystem>();
			enemy.Damage(dmg);
			enemy.Knockback (10f, gameObject.transform.position);
		}
	}
}
