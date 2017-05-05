using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float shakeTimer;
	public float shakeAmount;

	void Update () {
		//Finds a random position a small distance away from original, moves the camera there
		if (shakeTimer >= 0) {
			Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;

			transform.position = new Vector3 (transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);

			shakeTimer -= Time.deltaTime;
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