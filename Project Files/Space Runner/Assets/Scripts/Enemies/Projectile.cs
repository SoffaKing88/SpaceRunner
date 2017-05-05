using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	private float startTime;
	private float destroyTime;
	private AudioSource sound;

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
		sound = GetComponent<AudioSource> ();
		sound.pitch = Random.Range (-3f, 3f);
	}

	void Update(){
		startTime = Time.time;
		if (startTime > destroyTime)
			Destroy (gameObject);
	}
}
