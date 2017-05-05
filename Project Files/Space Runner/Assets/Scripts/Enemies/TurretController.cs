using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour {

	public float distance;
	public float shootInterval;
	public float bulletSpeed = 100;
	public float bulletTimer;
	public float lookRange;

	public GameObject bullet;
	public Transform target;
	public Transform shootPoint;

	private Transform turret;
	private bool facingRight = false;

	private AudioSource playSpot;
	public AudioClip[] sounds;

	void Start() {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		turret = this.gameObject.transform.GetChild (1);
		playSpot = GetComponent<AudioSource> ();
	}

	void Update() {
		RangeCheck ();
	}

	void RangeCheck() {
		distance = Vector3.Distance (transform.position, target.transform.position);
	}

	public void Attack() {
		//To make sure the tower only fires once every interval and not every frame
		bulletTimer += Time.deltaTime;

		if (bulletTimer >= shootInterval) {
			Vector2 direction = target.transform.position - transform.position;
			direction.Normalize ();

			playSpot.pitch = Random.Range(1f,1.1f);
			playSpot.PlayOneShot (sounds [0]);

			GameObject bulletClone;
			bulletClone = Instantiate (bullet, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
			bulletClone.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;

			bulletTimer = 0;
		}

		if(facingRight)
			turret.transform.right = target.position - turret.transform.position;
		else
			turret.transform.right = -(target.position - turret.transform.position);
		
		if (target.transform.position.x < transform.position.x && facingRight)
			Flip ();
		else if (target.transform.position.x > transform.position.x && !facingRight)
			Flip ();
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
