using UnityEngine;
using System.Collections;

public class SlugController : MonoBehaviour {

	private HealthSystem health;
	private Rigidbody2D rb2d;

	private bool facingRight = false;

	private float knockbackTime;

	private int moveTimer;
		
	void Start () {
		health = GetComponent<HealthSystem> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {
		if (health.tookDamage) {
			Knockback (400f);
			health.tookDamage = false;
		}

		if (knockbackTime > Time.time) {
			knockbackTime -= Time.deltaTime;
		}
	}

	public void Knockback(float knockPower) {
		if (facingRight) {
			rb2d.AddForce (new Vector2 (-knockPower, 1.5f * knockPower));
			Debug.Log (rb2d.velocity);
		}
		if (!facingRight) {
			rb2d.AddForce (new Vector2 (knockPower, 1.5f * knockPower));
			Debug.Log (rb2d.velocity);
		}
		knockbackTime = Time.time + 1f;
	}

}
