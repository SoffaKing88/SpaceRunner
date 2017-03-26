using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

	private HealthSystem enemy;
	//private SlugController slug;

	public int dmg = 1;

	// Finds the collider from whatever GameObject this hits, sees if it's an enemy and then does damage to it.
	void OnTriggerEnter2D(Collider2D col){
		//Debug.Log (col.gameObject);
		if (col.isTrigger != true && col.CompareTag ("Enemy")) {
			enemy = col.gameObject.GetComponent<HealthSystem>();
			enemy.Damage(dmg);
		}
	}
}
