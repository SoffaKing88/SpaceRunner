using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public int gemAmount = 0;
	public Text gemText;

	public GameObject[] levels;
	private Transform spawnPoint;
	private int index;
	private int lastIndex;
	private int[] validChoices;

	public float gameSpeed = 3f;

	void Start(){
		spawnPoint = GetComponent<Transform> ();
		index = 0;
		SpawnRooms(index);
		StartCoroutine (GottaGoFast ());
		StartCoroutine (GameStart ());
	}

	void Update() {
		//gemText.text = ("Gems: " + gemAmount);
		//Debug.Log (gemAmount);
		//Debug.Log(Time.time);
		transform.Translate (Vector3.left * gameSpeed * Time.deltaTime);

		if (spawnPoint.position.x < 35) {
			spawnPoint.position = new Vector3(spawnPoint.position.x + 35f, spawnPoint.position.y);
			index = Random.Range (0, levels.Length);
			if (lastIndex == 0 || (lastIndex == 0 && lastIndex == index)) {
				validChoices = new int[] {1, 2, 3};
				index = validChoices [Random.Range (0, validChoices.Length)];
				SpawnRooms (index);
			} else if (lastIndex == 1) {
				SpawnRooms (index);
			} else if (lastIndex == 2) {
				SpawnRooms (index);
			} else if (lastIndex == 3) {
				validChoices = new int[] {1, 2, 3, 4};
				index = validChoices [Random.Range (0, validChoices.Length)];
				SpawnRooms (index);
			} else if (lastIndex == 4) {
				validChoices = new int[] {1, 2, 3};
				index = validChoices [Random.Range (0, validChoices.Length)];
				SpawnRooms (index);
			}
		}
	}

	void SpawnRooms(int spawnIndex){
		//Debug.Log ("LI: " + lastIndex + " I: " + index);
		Instantiate (levels [spawnIndex], spawnPoint.position, spawnPoint.rotation);
		lastIndex = spawnIndex;
	}

	IEnumerator GottaGoFast(){
		for (int i = 0; i < 3; i++) {
			yield return new WaitForSeconds (30f);
			gameSpeed += 1f;
			Debug.Log ("GOTTA GO FAST");
		}
	}

	IEnumerator GameStart(){
		Time.timeScale = 0;
		Debug.Log ("Game Start in: ");
		for (int i = 3; i >= 0; i--) {
			Debug.Log (i);
			yield return new WaitForSecondsRealtime (1f);
		}
		Time.timeScale = 1;
	}
}
