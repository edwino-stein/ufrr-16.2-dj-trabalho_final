using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	public int life = 5;
	public int scoreForKill = 1000;
	protected Rigidbody rb;
	protected GameObject mainCamera;
	protected float speedCamera;
	protected float speed;

	protected bool isSlowDown = true;
	public float slowDownReduction = 2f;
	protected int slowingDownTimer;

	void Start(){
		this.rb = this.GetComponent<Rigidbody> ();
		this.mainCamera = Camera.main.gameObject;
		this.speedCamera = this.mainCamera.GetComponent<CameraController> ().speed;
		this.slowDown (10);
	}

	void Update () {
		Vector3 position = this.transform.position;
		position.z += this.speed;
		this.transform.position = position;
	}

	void slowDown(int timer){
		this.slowDownReduction = timer;
		this.isSlowDown = true;
		StartCoroutine("slowingDown");
	}

	IEnumerator slowingDown(){
		this.speed = this.speedCamera / this.slowDownReduction;
		yield return new WaitForSeconds (this.slowDownReduction);
		this.isSlowDown = false;
		this.speed = this.speedCamera;
	}

	void onBossPieceDie(GameObject subject){
		
		Debug.Log ("Destruiu algo do boss");
		Destroy (subject);
		this.life--;

		if (this.life == 3) {
			this.slowDown (3);
		}
		else if (this.life <= 0) {
			Debug.Log ("O Boss Morreu");
		}
	}
}
