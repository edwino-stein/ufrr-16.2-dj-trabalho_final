using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	
	protected Rigidbody rb;
	protected MeshRenderer mRenderer;

	public float speed = 1f;
	public string target = "Player";
	public float damage = 1f;

	public bool castShadows = false;

	void Start () {
		this.rb = GetComponent<Rigidbody>();
		this.mRenderer = GetComponent<MeshRenderer> ();

		if (!this.castShadows) {
			this.mRenderer.receiveShadows = false;
			this.mRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		}
	}

	void Update () {
		Vector3 velocity = this.rb.velocity;
		velocity.z = speed;
		this.rb.velocity = velocity;
	}
}
