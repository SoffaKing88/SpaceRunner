using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	private Animation anim;

	void Start () {
		StartCoroutine (Wait ());
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (0.2f);
		Destroy (gameObject);
	}
}
