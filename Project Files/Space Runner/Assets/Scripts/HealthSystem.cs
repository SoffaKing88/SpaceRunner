using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {

	private int maxHealth = 5;
	public int currentHealth;

	private Rigidbody2D rb2d;

	public LayerMask enemyLayer;
	public LayerMask obstacleLayer;

	void Start () {
		currentHealth = maxHealth;
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth > maxHealth)
			currentHealth = maxHealth;

		if (currentHealth <= 0)
			Die ();
	}

	public void Damage(int dmg) {
		currentHealth -= dmg;
	}

	void Die() {
		Destroy (gameObject);
	}

	public IEnumerator Knockback(float knockDuration, float knockPower, Vector3 knockDirection) {
		float time = 0;

		while (knockDuration > time) {
			time += Time.deltaTime;
			rb2d.AddForce (new Vector3 (knockDirection.x * -100, knockDirection.y + knockPower, transform.position.z));
		}

		yield return 0;
	}
}
