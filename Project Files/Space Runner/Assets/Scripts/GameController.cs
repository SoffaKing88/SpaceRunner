using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public int gemAmount = 0;
	public Text gemText;

	public GameObject[] levels;
	private Transform spawnPoint;
	private int index;

	void Start(){
		spawnPoint = GetComponent<Transform> ();
		
		for (int i = 0; i < 5; i++) {
			index = Random.Range (0, levels.Length);
			spawnPoint.position = new Vector3 (37f * i, 0, 0);
			Instantiate (levels [index], spawnPoint.position, spawnPoint.rotation);
		}
	}

	void Update() {
		//gemText.text = ("Gems: " + gemAmount);
		//Debug.Log (gemAmount);
	}
}
