using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
	
	public GameObject prefab;
	public Vector3 position;
	public bool initOnStart = false;

	void Start(){
		if (initOnStart)
			this.initPrefab();
	}

	public void initPrefab(){
		GameObject o = Instantiate (
			this.prefab,
			new Vector3(
				this.transform.position.x + this.position.x,
				this.transform.position.y + this.position.y,
				this.transform.position.z + this.position.z
			),
			this.transform.rotation
		);

		Destroy (this.transform.gameObject);
	}
}
