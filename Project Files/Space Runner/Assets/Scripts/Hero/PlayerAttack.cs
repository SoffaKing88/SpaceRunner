using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	private bool attacking = false;

	private float attackTimer = 0f;
	private float attackCD = 0.4f;

	public Collider2D attackTrigger;
	private Animator anim;

	private AudioSource playSpot;
	public AudioClip[] sounds;
	private float playTime;

	void Start() {
		// Make sure collider isn't automatically on and hitting things
		attackTrigger.enabled = false;
		anim = GetComponent<Animator> ();
		playSpot = GetComponent<AudioSource> ();
	}

	void Update() {
		// Attack as long as you aren't already in the middle of an attack
		if (Input.GetKeyDown ("c") && !attacking) {
			attacking = true;
			attackTimer = attackCD;

			attackTrigger.enabled = true;
		}

		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
				if (playTime < Time.time) {
					playSpot.PlayOneShot (sounds [0]);
					playTime = Time.time + sounds [0].length;
				}
			} else {
				attacking = false;
				attackTrigger.enabled = false;
			}
		}

		anim.SetBool ("Attacking", attacking);
	}
}
