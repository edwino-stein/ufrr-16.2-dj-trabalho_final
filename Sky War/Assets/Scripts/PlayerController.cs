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

	void Start () {
		this.rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		
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
				this.transform.Rotate(new Vector3(0, -5f, 0));
				this.rotate += 1;
			}

		} else if (Input.GetKey (this.leftKey)) {
			v.x = -speed;

			if (this.rotate > -this.maxRotate) {
				this.transform.Rotate(new Vector3(0, 5f, 0));
				this.rotate -= 1;
			}
		}
		else {
			v.x = 0;
			if (this.rotate < 0) {
				this.transform.Rotate (new Vector3 (0, -5f, 0));
				this.rotate += 1;
			}
			else if (this.rotate > 0) {
				this.transform.Rotate (new Vector3 (0, 5f, 0));
				this.rotate -= 1;
			}
		}

		this.rb.velocity = v;
	}
}
