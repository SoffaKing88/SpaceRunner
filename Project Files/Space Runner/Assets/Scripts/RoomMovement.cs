using UnityEngine;
using System.Collections;

public class RoomMovement : MonoBehaviour {

	private GameController controller;
	private float gameSpeed;

	void Start () {
		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
	}

	void Update () {
		gameSpeed = controller.gameSpeed;
		transform.Translate (Vector3.left * gameSpeed * Time.deltaTime);
		if (transform.position.x < -40)
			Destroy (gameObject);
	}
}
