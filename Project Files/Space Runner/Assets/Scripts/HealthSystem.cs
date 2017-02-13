using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HealthSystem : MonoBehaviour {

	private int maxHealth = 5;
	public int currentHealth;

	public LayerMask enemyLayer;
	public LayerMask obstacleLayer;

	void Start () {
		currentHealth = maxHealth;
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
}
