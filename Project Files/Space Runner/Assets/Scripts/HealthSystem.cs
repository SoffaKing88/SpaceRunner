using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {

	public int maxHealth = 5;
	public int currentHealth;

	private Rigidbody2D rb2d;

	public bool invincible = false;

	// Variable initiation
	void Start () {
		currentHealth = maxHealth;
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		// Health Management checking
		if (currentHealth > maxHealth)
			currentHealth = maxHealth;

		if (currentHealth <= 0)
			Die ();
	}

	public void Damage(int dmg) {
		if (!invincible) {
			currentHealth -= dmg;
			gameObject.GetComponent<Animation> ().Play ("Red_Flash");
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
