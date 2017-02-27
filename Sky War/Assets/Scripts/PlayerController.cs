using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public KeyCode upKey;
	public KeyCode downKey;
	public KeyCode leftKey;
	public KeyCode rightKey;

	public float speed = 1f;
	protected Rigidbody rb;
	protected float maxRotate = 5f;
	protected float rotate = 0f;
	protected GameObject gm;
	protected bool isDie = false;

	void Start () {
		this.rb = GetComponent<Rigidbody> ();
		this.gm = GameObject.Find ("GameMaster");
	}

	void Update () {

		if (this.isDie) {
			return;
		}

		Vector3 v = this.rb.velocity;

		if (Input.GetKey (this.upKey)) {
			v.z = speed;
		}
		else if (Input.GetKey (this.downKey)) {
			v.z = -speed;
		}
		else {
			v.z = 0;
		}

		if (Input.GetKey (this.rightKey)) {
			v.x = speed;

			if (this.rotate < this.maxRotate) {
				this.transform.Rotate(new Vector3(0, 0, -5f));
				this.rotate += 1;
			}

		} else if (Input.GetKey (this.leftKey)) {
			v.x = -speed;

			if (this.rotate > -this.maxRotate) {
				this.transform.Rotate(new Vector3(0, 0, 5f));
				this.rotate -= 1;
			}
		}
		else {
			v.x = 0;
			if (this.rotate < 0) {
				this.transform.Rotate (new Vector3 (0, 0, -5f));
				this.rotate += 1;
			}
			else if (this.rotate > 0) {
				this.transform.Rotate (new Vector3 (0, 0, 5f));
				this.rotate -= 1;
			}
		}

		this.rb.velocity = v;
	}

	IEnumerator dying(){
		CameraController c = Camera.main.GetComponent<CameraController> ();
		this.rb.useGravity = true;
		int explosions = 5;
		float delay = 0f;
		for (int i = 0; i < explosions; i++) {
			this.explode (new Vector2 (
				Random.Range (-5f, 5f),
				Random.Range (-5f, 5f)
			));

			c.speed /= 2;
			delay = Random.Range (0.5f, 0.7f);
			yield return new WaitForSeconds (delay);
		}

		c.speed = 0;
	}

	public void onSubjectDie(GameObject target){
		this.isDie = true;
		StartCoroutine("dying");
		this.gm.SendMessage ("onPlayerDie");
	}

	public void onSubjectTakeDamage(float damage){
		Debug.Log ("Player Tomou dano");
		this.gm.SendMessage ("resetCombo");
	}

	public void explode(Vector2 pos){
		GameObjectBundle gob = this.gm.GetComponent<GameObjectBundle> ();
		GameObject explosion = gob.Explosion;
		Vector3 t = this.transform.TransformPoint (Vector3.zero);

		GameObject e = Instantiate (
			explosion,
			new Vector3(
				t.x + pos.x,
				t.y,
				t.z + pos.y
			),
			this.transform.rotation
		);
		Destroy (e, 2f);
	}

}
