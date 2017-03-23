using UnityEngine;
using System.Collections;

public class SlugController : MonoBehaviour {

	private HealthSystem health;
	private HealthSystem heroHealth;
	private Transform heroTrans;
	private Rigidbody2D rb2d;

	private bool facingRight = false;

	private float knockbackTime;

	private float moveTimer;

	public Transform wallCheck;
	private bool hittingWall = false;
	float wallRadius = 0.2f;
	public LayerMask wallLayer;
		
	void Start () {
		health = GetComponent<HealthSystem> ();
		heroHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<HealthSystem> ();
		heroTrans = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallRadius, wallLayer);

		if (hittingWall)
			Flip ();
			

		if (health.tookDamage) {
			Knockback (400f);
			health.tookDamage = false;
		}

		if (knockbackTime > Time.time) {
			knockbackTime -= Time.deltaTime;
		}
			moveTimer++;

		if (moveTimer > 40 && !facingRight && knockbackTime < Time.time) {
			rb2d.AddForce (new Vector2(-10f - moveTimer/1.5f, rb2d.velocity.y));
		}
		if (moveTimer > 40 && facingRight && knockbackTime < Time.time) {
			rb2d.AddForce (new Vector2(10f + moveTimer/1.5f, rb2d.velocity.y));
		}

		if (moveTimer >= 50) {
			moveTimer = 0;
		}
	}

	public void Knockback(float knockPower) {
		if (heroTrans.position.x > transform.position.x) {
			rb2d.AddForce (new Vector2 (-knockPower, 1.5f * knockPower));
			Debug.Log (rb2d.velocity);
		} else {
			rb2d.AddForce (new Vector2 (knockPower, 1.5f * knockPower));
			Debug.Log (rb2d.velocity);
		}
		knockbackTime = Time.time + 2f;
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		//Debug.Log ("Flip:" + facingRight);
	}

	void OnTriggerStay2D(Collider2D enter) {
		if (!heroHealth.invincible){
			if (enter.CompareTag ("Player")) {
				heroHealth.Damage (1);
			}
		}
	}

}
