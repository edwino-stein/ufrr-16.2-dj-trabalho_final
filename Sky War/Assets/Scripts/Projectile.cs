using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	
	protected Rigidbody rb;

	public float speed = 1f;
	public float baseSpeed = 1000;
	public string target = "Player";
	public float damage = 1f;
	public bool castShadows = false;

	void Start () {
		this.rb = GetComponent<Rigidbody>();
	}

	public void setDirection(Vector3 direction){
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.AddForce (direction.normalized * this.baseSpeed * this.speed);
	}
}
