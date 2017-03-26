using UnityEngine;
using System.Collections;

public class TurretAttackRange : MonoBehaviour {

	public TurretController turretController;

	void Awake() {
		turretController = gameObject.GetComponentInParent<TurretController> ();
	}

	void OnTriggerStay2D(Collider2D col){

		if (col.CompareTag ("Player")) {
			turretController.Attack ();
		}
	}
}
