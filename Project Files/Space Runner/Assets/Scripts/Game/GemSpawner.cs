using UnityEngine;
using System.Collections;

public class GemSpawner : MonoBehaviour {

	private GameController gcontroller;

	public GameObject gem;
	private bool spaceCheck = true;
	private float seconds;

	private float gameSpeed;
	private Vector3 direction = Vector3.up;

	// Use this for initialization
	void Start () {
		gcontroller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
		gameSpeed = gcontroller.gameSpeed;
		StartCoroutine (SpawnGem ());
	}

	void Update() {
		gameSpeed = gcontroller.gameSpeed;
		if (transform.position.y >= 5) {
			direction = Vector3.down;
		} else if (transform.position.y <= -5) {
			direction = Vector3.up;
		}
		transform.Translate (direction * Time.deltaTime * gameSpeed, Space.World);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.isTrigger != true) {
			if (col.CompareTag ("Ground")) {
				spaceCheck = false;
			}
		}
	}

	void OnTriggerExit2D(Collider2D col){
		spaceCheck = true;
	}

	IEnumerator SpawnGem(){
		if (spaceCheck) {
			Instantiate (gem, transform.position, transform.rotation);
			seconds = Random.Range (1f, (12f / gameSpeed));
		} else {
			seconds = Random.Range (0f, 0.3f);
		}
		yield return new WaitForSeconds (seconds);
		StartCoroutine (SpawnGem ());
	}
}
