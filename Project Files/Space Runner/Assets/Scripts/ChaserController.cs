using UnityEngine;
using System.Collections;

public class ChaserController : MonoBehaviour {

	private GameObject hero;
	private HealthSystem heroHealth;
	private Transform heroTrans;
	private Rigidbody2D rb2d;

	private float maxSpeed = 20f;

	public Transform groundCheck;
	private bool grounded = false;
	float groundRadius = 0.2f;
	public LayerMask groundLayer;

	void Start () {
		hero = GameObject.FindGameObjectWithTag ("Player");
		heroHealth = hero.GetComponent<HealthSystem> ();
		heroTrans = hero.GetComponent<Transform> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {
		//If player is invincible allow player to pass through the enemy
		if(heroHealth.invincible){
			Physics2D.IgnoreCollision (hero.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D> ());
		}

		//Movement Management
		if (heroTrans.transform.position.x < transform.position.x)
			rb2d.AddForce (new Vector2(-30f, rb2d.velocity.y));
		if (heroTrans.transform.position.x > transform.position.x)
			rb2d.AddForce (new Vector2(30f, rb2d.velocity.y));

		if (rb2d.velocity.x > maxSpeed)
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
		if (rb2d.velocity.y > maxSpeed)
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);

		//Jumping Management
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, groundLayer);

		if (heroTrans.transform.position.x - 3f <= transform.position.x && heroTrans.transform.position.y > transform.position.y + 3f && grounded)
			rb2d.AddForce (new Vector2 (rb2d.velocity.x, 200f));
		if (heroTrans.transform.position.x + 3f >= transform.position.x && heroTrans.transform.position.y > transform.position.y + 3f && grounded)
			rb2d.AddForce (new Vector2 (rb2d.velocity.x, 200f));
	}

	void OnTriggerStay2D(Collider2D enter) {
		if (!heroHealth.invincible){
			if (enter.CompareTag ("Player")) {
				heroHealth.Damage (3);
				Destroy (gameObject);
			}
		}
	}
}
