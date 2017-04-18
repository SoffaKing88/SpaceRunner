using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public int gemAmount = 0;
	public Text gemText;

	public GameObject[] levels;
	private Transform spawnPoint;
	private int index;

	public float gameSpeed = 3f;

	void Start(){
		spawnPoint = GetComponent<Transform> ();
		Instantiate (levels [0], spawnPoint.position, spawnPoint.rotation);
		spawnPoint.position = new Vector3(spawnPoint.position.x + 35f, spawnPoint.position.y);
		index = Random.Range (0, levels.Length);
		Instantiate (levels [index], spawnPoint.position, spawnPoint.rotation);
		//StartCoroutine(SpawnRoom());
		StartCoroutine (GottaGoFast ());
	}

	void Update() {
		//gemText.text = ("Gems: " + gemAmount);
		//Debug.Log (gemAmount);
		//Debug.Log(Time.time);
		Debug.Log(Time.time);
		transform.Translate (Vector3.left * gameSpeed * Time.deltaTime);

		if (spawnPoint.position.x < 0) {
			spawnPoint.position = new Vector3(spawnPoint.position.x + 35f, spawnPoint.position.y);
			index = Random.Range (0, levels.Length);
			Instantiate (levels [index], spawnPoint.position, spawnPoint.rotation);
		}
	}

	/*IEnumerator SpawnRoom(){
		index = Random.Range (0, levels.Length);
		Instantiate (levels [index], spawnPoint.position, spawnPoint.rotation);
		Debug.Log("SPAWN " + (gameSpeed));
		yield return new WaitForSeconds (gameSpeed * timer);
		StartCoroutine (SpawnRoom ());
	}*/

	IEnumerator GottaGoFast(){
		for (int i = 0; i < 3; i++) {
			yield return new WaitForSeconds (30f);
			gameSpeed += 1f;
		}
	}
}
