using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	private float startTime;
	private float destroyTime;

	void OnTriggerEnter2D(Collider2D col){
		if (col.isTrigger != true) {
			if (col.CompareTag ("Player")) {
				col.GetComponent<HealthSystem> ().Damage (1);
				if (col.GetComponent<HealthSystem> ().tookDamage == true) {
					Destroy (gameObject);
				}
			}
			if (col.CompareTag ("Ground")) {
				Destroy (gameObject);
			}
		}
	}

	void Start() {
		destroyTime = Time.time + 5f;
	}

	void Update(){
		startTime = Time.time;
		if (startTime > destroyTime)
			Destroy (gameObject);
	}
}
