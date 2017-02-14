using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	
	protected Rigidbody rb;
	public float speed = 1f;
	public string target = "Player";

	void Start () {
		this.rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		Vector3 velocity = this.rb.velocity;
		velocity.z = speed;
		this.rb.velocity = velocity;
	}
}
