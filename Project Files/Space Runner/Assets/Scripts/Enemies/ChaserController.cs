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

	private Animator anim;
	private bool facingRight = true;
	private HealthSystem health;

	private AudioSource playSpot;
	public AudioClip[] sounds;
	private float playTime = 0f;

	void Start () {
		hero = GameObject.FindGameObjectWithTag ("Player");
		heroHealth = hero.GetComponent<HealthSystem> ();
		heroTrans = hero.GetComponent<Transform> ();
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		health = GetComponent<HealthSystem> ();
		playSpot = GetComponent<AudioSource> ();
	}

	void Update () {
		anim.SetFloat ("Speed", Mathf.Abs(rb2d.velocity.x));

		if (Mathf.Abs(rb2d.velocity.x) > 0.1f && playTime < Time.time) {
			playSpot.pitch = Random.Range(1f,1.5f);
			playSpot.PlayOneShot(sounds[0]);
			playTime = Time.time + sounds [0].length - 0.1f;
		}
	}

	void FixedUpdate() {
		//If player is invincible allow player to pass through the enemy
		if(heroHealth.invincible){
			Physics2D.IgnoreCollision (hero.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D> ());
		}

		//Movement Management
		if (heroTrans.transform.position.x < transform.position.x && (transform.position.x - heroTrans.transform.position.x) < 15)
			rb2d.AddForce (new Vector2(-30f, rb2d.velocity.y));
		if (heroTrans.transform.position.x > transform.position.x && (heroTrans.transform.position.x - transform.position.x ) < 15)
			rb2d.AddForce (new Vector2(30f, rb2d.velocity.y));

		if (rb2d.velocity.x > maxSpeed)
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
		if (rb2d.velocity.y > maxSpeed)
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);

		//Jumping Management
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, groundLayer);

		if (heroTrans.transform.position.x - 3f <= transform.position.x && heroTrans.transform.position.y > transform.position.y + 3f && grounded && (transform.position.x - heroTrans.transform.position.x) < 15)
			rb2d.AddForce (new Vector2 (rb2d.velocity.x, 200f));
		if (heroTrans.transform.position.x + 3f >= transform.position.x && heroTrans.transform.position.y > transform.position.y + 3f && grounded && (heroTrans.transform.position.x - transform.position.x ) < 15)
			rb2d.AddForce (new Vector2 (rb2d.velocity.x, 200f));

		if (rb2d.velocity.x > 0 && !facingRight)
			Flip ();
		else if (rb2d.velocity.x < 0 && facingRight)
			Flip ();
	}

	void OnTriggerStay2D(Collider2D enter) {
		if (!heroHealth.invincible){
			if (enter.CompareTag ("Player")) {
				heroHealth.Damage (2);
				Instantiate (health.explosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
