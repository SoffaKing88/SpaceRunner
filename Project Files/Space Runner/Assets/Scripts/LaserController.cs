using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour {

	public float laserDelay;
	public float laserFireTime;

	private Collider2D laser;
	private SpriteRenderer beam;

	void Start() {
		laser = GetComponent<Collider2D> ();
		beam = GameObject.Find("Beam").GetComponent<SpriteRenderer>();
		laser.enabled = false;
		beam.enabled = false;
		StartCoroutine (FireLaser ());
		Debug.Log (beam);
	}

	IEnumerator FireLaser() {
		laser.enabled = !laser.enabled;
		beam.enabled = !beam.enabled;
		yield return new WaitForSeconds (laserFireTime);
		laser.enabled = !laser.enabled;
		beam.enabled = !beam.enabled;
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
