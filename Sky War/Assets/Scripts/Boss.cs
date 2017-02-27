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
	protected GameObject gm;

	protected bool isPaused = false;

	void Start(){
		this.rb = this.GetComponent<Rigidbody> ();
		this.gm = GameObject.Find ("GameMaster");
		this.mainCamera = Camera.main.gameObject;
		this.speedCamera = this.mainCamera.GetComponent<CameraController> ().speed;
		this.slowDown (10);
		Camera.main.SendMessage ("onBossSpawn");
	}

	void Update () {
		if (!this.isPaused) {
			Vector3 position = this.transform.position;
			position.z += this.speed;
			this.transform.position = position;
		}
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

	IEnumerator dying(){
		int explosions = (int)Random.Range (50f, 60f);
		float delay = 0f;
		for (int i = 0; i < explosions; i++) {
			this.explode (new Vector2 (
				Random.Range (-15f, 15f),
				Random.Range (-60f, 60f)
			));
			delay = Random.Range (0.1f, 0.3f);
			yield return new WaitForSeconds (delay);
		}
	}

	void onBossPieceDie(GameObject subject){
		
		Debug.Log ("Destruiu algo do boss");
		this.life--;

		if (this.life == 3) {
			this.slowDown (3);
		}
		else if (this.life <= 0) {
			this.gm.SendMessage ("onBossDie");
			this.slowDown (20);
			StartCoroutine("dying");
		}
	}

	public void explode(Vector2 pos){
		GameObjectBundle gob = this.gm.GetComponent<GameObjectBundle> ();
		GameObject explosion = gob.Explosion;
		GameObject e = Instantiate (
			explosion,
			new Vector3(
				this.transform.position.x + pos.x,
				this.transform.position.y,
				this.transform.position.z + pos.y
			),
			this.transform.rotation
		);
		Destroy (e, 2f);
	}

	void setPause(bool pause){
		this.isPaused = pause;
	}
}
