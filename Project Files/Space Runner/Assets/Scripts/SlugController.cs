using UnityEngine;
using System.Collections;

public class SlugController : MonoBehaviour {

	private HealthSystem health;
	private Rigidbody2D rb2d;

	private bool facingRight = false;
		
	void Start () {
		health = GetComponent<HealthSystem> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update() {
		if (health.tookDamage) {
			Knockback (10f);
		}
	}

	public void Knockback(float knockPower) {
		if (!health.invincible && facingRight) {
			rb2d.velocity = new Vector2 (-knockPower, knockPower);
		}
		if (!health.invincible && !facingRight) {
			rb2d.velocity = new Vector2 (knockPower, knockPower);
		}
	}

}
