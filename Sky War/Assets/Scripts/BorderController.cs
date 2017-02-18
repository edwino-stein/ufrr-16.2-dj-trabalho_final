using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderController : MonoBehaviour {

	public string projectileTag = "Projectile";
	public string spawnerTag = "Spawner";

	public bool initSpawners = false;
	public bool destroyObjects = false;

	void OnTriggerEnter(Collider other) {
		
		if (other.tag == this.projectileTag) {
			Destroy(other.gameObject);
			return;
		}

		if (this.initSpawners && other.tag == this.spawnerTag) {
			other.gameObject.GetComponent<EnemySpawn> ().initPrefab ();
			return;
		}

		if (this.destroyObjects) {
			Destroy(other.gameObject);
			return;
		}
	}
}
