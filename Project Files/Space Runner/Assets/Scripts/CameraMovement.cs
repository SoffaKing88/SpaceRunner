using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private GameObject player;
	private float moveSpeed = 0.8f;

	private Vector3 gameDirection = Vector3.right;

	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");

	}

	void Update () {
		transform.Translate (gameDirection * moveSpeed * Time.deltaTime);
	}

}