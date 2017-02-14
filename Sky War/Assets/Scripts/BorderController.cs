using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderController : MonoBehaviour {

	public string projectileTag = "Projectile";

	void OnTriggerEnter(Collider other) {
		if (other.tag == this.projectileTag) {
			Destroy(other.gameObject);
		}
	}
}
