using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HealthSystem : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;
	public int invincibleTime;

	public bool tookDamage;

	public bool invincible = false;

	public Animation[] children;
	public GameObject explosion;

	// Variable initiation
	void Start () {
		currentHealth = maxHealth;
		children = GetComponentsInChildren<Animation> ();
	}

	void Update () {
		// Health Management checking
		if (currentHealth > maxHealth)
			currentHealth = maxHealth;
	}

	public bool Damage(int dmg) {
		//returning tookDamage is used for Knockback in movement scripts
		tookDamage = false;
		if (!invincible) {
			currentHealth -= dmg;
			gameObject.GetComponent<Animation> ().Play ("Red_Flash");
			if (children.Length > 0) {
				for (int i = 0; i < children.Length; i++) {
					children [i].Play ("Red_Flash");
				}
			}
			tookDamage = true;
			invincible = true;
			Invoke ("resetInvincibility", invincibleTime);
		}

		if (currentHealth <= 0) {
			Instantiate (explosion, transform.position, transform.rotation);
			Die ();
		}

		return tookDamage;
	}

	void resetInvincibility() {
		invincible = false;
	}

	void Die() {
		if (gameObject.CompareTag ("Player")) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
		Destroy (gameObject);
	}
}
