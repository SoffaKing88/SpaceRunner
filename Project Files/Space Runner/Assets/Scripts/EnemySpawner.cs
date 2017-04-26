using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public Transform[] spawnPoints;

	private GameController gControl;
	private float chance;
	private float spawn = 70f;
	private GameObject[] enemies;

	// Use this for initialization
	void Start () {
		gControl = GameObject.Find ("GameController").GetComponent<GameController>();
		enemies = gControl.enemies;
		chance = Random.Range (0f, 100f);
		for (int i = 0; i < spawnPoints.Length; i++) {
			if (chance > spawn) {
				Instantiate (enemies [Random.Range (0, enemies.Length)], spawnPoints [i].position, spawnPoints[i].rotation);
				spawn += 15;
			} else {
				spawn -= 20;
			}
		}
	}
}
