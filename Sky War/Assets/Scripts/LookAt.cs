using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

	public GameObject target;

	public bool freezeX = false;
	public bool freezeY = false;
	public bool freezeZ = false;

	void Update () {

		if (this.target == null)
			return;

		this.transform.LookAt (new Vector3 (
			freezeX ? this.transform.position.x : this.target.transform.position.x,
			freezeY ? this.transform.position.y : this.target.transform.position.y,
			freezeZ ? this.transform.position.z : this.target.transform.position.z
		));
	}
}
