using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour {

	public float laserDelay;
	public float laserFireTime;

	private Collider2D laser;

	void Start() {
		laser = GetComponent<Collider2D> ();
		laser.enabled = false;
		StartCoroutine (FireLaser ());
	}

	IEnumerator FireLaser() {
		laser.enabled = !laser.enabled;
		yield return new WaitForSeconds (laserFireTime);
		laser.enabled = !laser.enabled;
		yield return new WaitForSeconds (laserDelay);
		StartCoroutine (FireLaser ());
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.isTrigger != true) {
			if (col.CompareTag ("Player")) {
				col.GetComponent<HealthSystem> ().Damage (1);
			}
		}
	}
}
