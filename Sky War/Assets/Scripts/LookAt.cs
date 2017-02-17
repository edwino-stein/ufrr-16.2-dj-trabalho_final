using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

	public GameObject target;

	void Update () {
		this.transform.LookAt (this.target.transform);
	}
}
