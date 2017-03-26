﻿using UnityEngine;
using System.Collections;

public class ChaserController : MonoBehaviour {

	private GameObject hero;
	private HealthSystem health;
	private HealthSystem heroHealth;
	private Transform heroTrans;
	private Rigidbody2D rb2d;

	private float maxSpeed = 20f;

	void Start () {
		health = GetComponent<HealthSystem> ();
		hero = GameObject.FindGameObjectWithTag ("Player");
		heroHealth = hero.GetComponent<HealthSystem> ();
		heroTrans = hero.GetComponent<Transform> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {
		if(heroHealth.invincible){
			Physics2D.IgnoreCollision (hero.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D> ());
		}

		if (heroTrans.transform.position.x < transform.position.x)
			rb2d.AddForce (new Vector2(-30f, rb2d.velocity.y));
		if (heroTrans.transform.position.x > transform.position.x)
			rb2d.AddForce (new Vector2(30f, rb2d.velocity.y));

		if (rb2d.velocity.x > maxSpeed)
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
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