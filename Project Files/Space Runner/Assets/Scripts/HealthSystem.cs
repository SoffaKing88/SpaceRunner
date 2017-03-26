using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;
	public int invincibleTime;

	public bool tookDamage;

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

	public bool Damage(int dmg) {
		//returning tookDamage is used for Knockback in movement scripts
		tookDamage = false;
		if (!invincible) {
			currentHealth -= dmg;
			gameObject.GetComponent<Animation> ().Play ("Red_Flash");
			tookDamage = true;
			invincible = true;
			Invoke ("resetInvincibility", invincibleTime);
		}
		return tookDamage;
	}

	void resetInvincibility() {
		invincible = false;
	}

	void Die() {
		Destroy (gameObject);
	}
}
