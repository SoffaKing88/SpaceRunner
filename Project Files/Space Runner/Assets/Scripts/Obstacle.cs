using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private HealthSystem hero;

	void Start(){
		hero = GameObject.FindGameObjectWithTag ("Player").GetComponent<HealthSystem> ();
	}

	void OnTriggerEnter2D(Collider2D enter) {
		if (enter.CompareTag ("Player")) {
			hero.Damage (1);

			StartCoroutine (hero.Knockback (0.02f, 350f, hero.transform.position));
		}
	}
}
