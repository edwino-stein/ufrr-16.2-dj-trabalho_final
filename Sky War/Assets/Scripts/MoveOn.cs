using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOn : MonoBehaviour {

	public float speed = 1f;
	public float baseSpeed = 1000;
	protected Rigidbody rb;

	void Start () {
		this.rb = GetComponent<Rigidbody>();
		this.rb.AddForce (this.transform.forward * this.speed * this.baseSpeed);
	}

}
