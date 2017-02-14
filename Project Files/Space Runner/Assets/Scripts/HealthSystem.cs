using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {

	private int maxHealth = 5;
	public int currentHealth;

	private Rigidbody2D rb2d;

	public LayerMask enemyLayer;
	public LayerMask obstacleLayer;

	public bool invincible = false;

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
		if (!invincible) {
			currentHealth -= dmg;
			invincible = true;
			Invoke ("resetInvincibility", 2);
		}
	}

	void resetInvincibility() {
		invincible = false;
	}

	void Die() {
		Destroy (gameObject);
	}

	public void Knockback(float knockPower, Vector3 knockDirection) {
		if (!invincible) {
			rb2d.velocity = new Vector2 (rb2d.velocity.x, knockDirection.y + knockPower);
		}
	}
}
