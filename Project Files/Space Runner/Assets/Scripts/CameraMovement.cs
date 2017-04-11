using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private float moveSpeed = 0.8f;

	private Vector3 gameDirection = Vector3.right;

	public float shakeTimer;
	public float shakeAmount;

	void Update () {
		//Slowly Moves Camera to the right. Will implement speed up later on
		//transform.Translate (gameDirection * moveSpeed * Time.deltaTime);

		//Finds a random position a small distance away from original, moves the camera there
		if (shakeTimer >= 0) {
			Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;

			transform.position = new Vector3 (transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);

			shakeTimer -= Time.deltaTime;
		}
			
		//Used for testing Camera Shake, will use different trigger later on
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

	//Function in case Shaking is more or less powerful, or longer or shorter
	public void ShakeCamera(float shakePower, float shakeDuration) {
		shakeAmount = shakePower;
		shakeTimer = shakeDuration;
	}

}