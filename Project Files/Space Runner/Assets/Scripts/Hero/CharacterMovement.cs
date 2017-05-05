using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	//Used for horizontal movement
	private bool facingRight = true;
	public float maxSpeed = 15f;
	public float knockbackTime;

	//Used for Jumping
	public float jumpForce = 500f;
	public Transform groundCheck;
	private bool grounded = false;
	float groundRadius = 0.2f;
	public LayerMask groundLayer;
	private bool doubleJump = false;

	private Rigidbody2D rb2d;
	private GameController gc;
	private HealthSystem health;

	private Animator anim;

	private AudioSource playSpot;
	public AudioClip[] sounds;
	private float timeCheck = 0f;

	//Initiate objects in variables
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		gc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		health = GetComponent<HealthSystem> ();
		anim = GetComponent<Animator> ();
		playSpot = GetComponent<AudioSource> ();
	}

	void FixedUpdate () {
		//Check which direction Character is moving, and move that direction
		float move = Input.GetAxis ("Horizontal");

		//Speed Management
		if (move != 0 && knockbackTime < Time.time) {
			rb2d.velocity = new Vector2 (move * maxSpeed, rb2d.velocity.y);
		}
		if (rb2d.velocity.y > maxSpeed) {
			rb2d.velocity = new Vector2 (rb2d.velocity.x, maxSpeed);
		}
		if (rb2d.velocity.y < -maxSpeed) {
			rb2d.velocity = new Vector2 (rb2d.velocity.x, -maxSpeed);
		}
		if (move == 0 && facingRight && grounded) {
			transform.Translate (Vector3.left * gc.gameSpeed * Time.deltaTime);
		} else if (move == 0 && !facingRight && grounded) {
			transform.Translate (Vector3.right * gc.gameSpeed * Time.deltaTime);
		}

		//Flip Character Direction (Sprite, colliders, etc.)
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

		//Check if Character is on the ground, if so allow a double jump
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, groundLayer);

		if (grounded) {
			doubleJump = false;
			anim.SetBool ("Jumping", false);
		} else if (!grounded) {
			anim.SetBool ("Jumping", true);
		}

		if (health.tookDamage) {
			Knockback (400f);
			health.tookDamage = false;
		}

		if (knockbackTime > Time.time) {
			knockbackTime -= Time.deltaTime;
		}
	}

	void Update () {
		//If character is grounded or hasn't used their double jump and the space bar is hit, Jump
		if ((grounded || !doubleJump) && Input.GetKeyDown (KeyCode.Space)) {
			rb2d.AddForce(new Vector2(0, jumpForce));
			anim.SetBool ("Jumping", true);

			if (!doubleJump && !grounded)
				doubleJump = true;
		}

		anim.SetFloat ("X Speed", Mathf.Abs(rb2d.velocity.x));
		anim.SetFloat ("Y Speed", Mathf.Abs(rb2d.velocity.y));

		if (Mathf.Abs(rb2d.velocity.x) > 0.1f && grounded && timeCheck < Time.time) {
			playSpot.PlayOneShot (sounds [0]);
			timeCheck = Time.time + sounds [0].length;
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D(Collider2D col){
		//If character hits a gem, destroy it and add to gem counter
		if (col.CompareTag ("Gem")) {
			Destroy (col.gameObject);
			gc.gemAmount += 1;
			playSpot.PlayOneShot (sounds [1]);
		}
	}

	public void Knockback(float knockPower) {
		if (facingRight) {
			rb2d.AddForce(new Vector2 (-knockPower, 1.5f * knockPower));
		} else {
			rb2d.AddForce(new Vector2 (knockPower, 1.5f * knockPower));
		}
		knockbackTime = Time.time + 1f;
	}
}
