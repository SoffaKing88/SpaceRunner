using UnityEngine;
using System.Collections;

public class ScrollController : MonoBehaviour {

	private GameController gcontroller;

	private float gameSpeed;

	void Start () {
		gcontroller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
	}

	void Update () {
		gameSpeed = gcontroller.gameSpeed;
		transform.Translate (Vector3.left * gameSpeed * Time.deltaTime, Space.World);
		if (transform.position.x < -40)
			Destroy (gameObject);
	}
}
