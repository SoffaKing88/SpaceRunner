using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DeathFalls : MonoBehaviour {

	public GameObject hero;
	private float fallDeath = -8f;
	private float backDeath = -19f;

	void Update(){
		if (hero.transform.position.y < fallDeath)
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

		if (hero.transform.position.x < backDeath)
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
