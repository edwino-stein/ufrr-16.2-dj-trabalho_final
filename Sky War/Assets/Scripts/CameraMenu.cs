using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenu : MonoBehaviour {

	public GameObject water;

	public float waterTailPos = -5000;
	public float speed = 1f;

	protected float nextPos = 0;
	protected float height = -1;

	void Start(){
		this.nextPos = this.waterTailPos;
	}

	// Update is called once per frame
	void Update () {
		Vector3 pos = this.transform.position;
		pos.z -= this.speed;
		this.transform.position = pos;

		if (pos.z <= this.nextPos) {
			Instantiate (
				this.water,
				new Vector3(
					this.water.transform.position.x,
					this.water.transform.position.y + this.height,
					this.nextPos
				),
				this.water.transform.rotation
			);

			this.nextPos += waterTailPos;
			this.height *= (-1);
		}
	}
}
