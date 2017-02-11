using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	private bool facingRight = true;
	private bool jump = false;

	//public float moveForce = 1000f;
	public float maxSpeed = 15f;
	public float jumpForce = 800f;

	public Transform groundCheck;
	private bool grounded = false;
	float groundRadius = 0.2f;
	public LayerMask groundLayer;

	private Rigidbody2D rb2d;

	void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");
		Debug.Log (move);

		rb2d.velocity = new Vector2 (move * maxSpeed, rb2d.velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, groundLayer);
	}

	void Update () {
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			rb2d.AddForce(new Vector2(0, jumpForce));
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		Debug.Log ("Flip");
	}
}
