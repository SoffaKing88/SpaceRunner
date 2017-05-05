using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

	public Sprite[] heartSprites;

	public Image heartUI;

	private HealthSystem hero;

	void Start() {
		hero = GameObject.FindGameObjectWithTag ("Player").GetComponent<HealthSystem> ();
	}

	void Update() {
		heartUI.sprite = heartSprites [hero.currentHealth];
	}
}
