using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	private SpriteRenderer sprite;

	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
		StartCoroutine (Wait ());
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (0.2f);
		sprite.enabled = false;
		yield return new WaitForSeconds (2f);
		Destroy (gameObject);
	}
}
