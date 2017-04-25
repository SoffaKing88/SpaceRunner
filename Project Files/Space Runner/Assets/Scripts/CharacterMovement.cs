using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	//Used for horizontal movement
	private bool facingRight = true;
	public float maxSpeed = 15f;

	//Used for Jumping
	public float jumpForce = 500f;
	public Transform groundCheck;
	private bool grounded = false;
	float groundRadius = 0.2f;
	public LayerMask groundLayer;
	private bool doubleJump = false;

	private Rigidbody2D rb2d;
	private GameController gm;
	private HealthSystem health;

	public float knockbackTime;

	//Initiate objects in variables
	void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
		gm = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		health = GetComponent<HealthSystem> ();
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
			transform.Translate (Vector3.left * gm.gameSpeed * Time.deltaTime);
		} else if (move == 0 && !facingRight && grounded) {
			transform.Translate (Vector3.right * gm.gameSpeed * Time.deltaTime);
		}

		//Flip Character Direction (Sprite, colliders, etc.)
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

		//Check if Character is on the ground, if so allow a double jump
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, groundLayer);

		if (grounded)
			doubleJump = false;

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

			if (!doubleJump && !grounded)
				doubleJump = true;
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
			gm.gemAmount += 1;
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
