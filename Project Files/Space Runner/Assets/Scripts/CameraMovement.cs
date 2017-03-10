using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	//private GameObject player;
	private float moveSpeed = 0.8f;

	private Vector3 gameDirection = Vector3.right;

	public float shakeTimer;
	public float shakeAmount;

	void Start () {

		//player = GameObject.FindGameObjectWithTag ("Player");

	}

	void Update () {
		//transform.Translate (gameDirection * moveSpeed * Time.deltaTime);

		if (shakeTimer >= 0) {
			Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;

			transform.position = new Vector3 (transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);

			shakeTimer -= Time.deltaTime;
		}
			
		if (Input.GetButtonDown ("Fire1")) {
			ShakeCamera (0.05f, 1);
		}

		//Slowly resets camera when shake bumps it too far up or down
		if (transform.position.y >= 0) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - (transform.position.y / 2), transform.position.z);
		}
		if (transform.position.y <= 0) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + (Mathf.Abs(transform.position.y) / 2), transform.position.z);
		}
	}

	public void ShakeCamera(float shakePower, float shakeDuration) {
		shakeAmount = shakePower;
		shakeTimer = shakeDuration;
	}

}