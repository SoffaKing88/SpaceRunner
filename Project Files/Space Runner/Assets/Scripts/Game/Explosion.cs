using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	private SpriteRenderer sprite;
	private CameraMovement mainCamera;

	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
		mainCamera = GameObject.Find ("Main Camera").GetComponent<CameraMovement>();
		mainCamera.ShakeCamera (0.05f, 1);
		StartCoroutine (Wait ());
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (0.2f);
		sprite.enabled = false;
		yield return new WaitForSeconds (2f);
		Destroy (gameObject);
	}
}
