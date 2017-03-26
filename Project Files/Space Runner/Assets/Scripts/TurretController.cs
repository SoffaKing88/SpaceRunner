using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour {

	public float distance;
	public float shootInterval;
	public float bulletSpeed = 100;
	public float bulletTimer;
	public float lookRange;

	public GameObject bullet;
	private HealthSystem health;
	public Transform target;
	public Transform shootPoint;

	void Start() {
		health = GetComponent<HealthSystem> ();
	}

	void Update() {
		RangeCheck ();
	}

	void RangeCheck() {
		distance = Vector3.Distance (transform.position, target.transform.position);
	}

	public void Attack() {
		bulletTimer += Time.deltaTime;

		if (bulletTimer >= shootInterval) {
			Vector2 direction = target.transform.position - transform.position;
			direction.Normalize ();

			GameObject bulletClone;
			bulletClone = Instantiate (bullet, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
			bulletClone.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;

			bulletTimer = 0;
		}
	}
}
