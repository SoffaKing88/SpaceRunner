using UnityEngine;
using System.Collections;

public class BgScroller : MonoBehaviour {

	private GameController gc;
	public GameObject nextBackground;
	private bool sent;

	// Use this for initialization
	void Start () {
		gc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate ((Vector3.left * gc.gameSpeed * Time.deltaTime) / 2, Space.World);
		if (transform.position.x < -13 && !sent) {
			Instantiate (nextBackground, new Vector3 (transform.position.x + 61, transform.position.y, 30), transform.rotation);
			sent = true;
		} else if (transform.position.x < -48) {
			Destroy (gameObject);
		}
	}
}
