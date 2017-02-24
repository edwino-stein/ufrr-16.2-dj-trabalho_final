using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon2 : MonoBehaviour {

	public GameObject projectile; 
	public float timer = 1f;
	public float delayToStart = 0f;
	public float sequenceTimer = 0.5f;
	public int sequenceShoots = 5;
	public bool allowShoot = true;
	public float posY;

	protected int counter = 0;
	protected GameObject fx;

	protected Transform mainCamera;

	void Start () {
		this.transform.position = new Vector3 (
			this.transform.position.x,
			this.transform.position.y + (posY - this.transform.position.y),
			this.transform.position.z
		);

		this.mainCamera = Camera.main.transform;
		GameObjectBundle gob = GameObject.Find ("GameObjectBundle").GetComponent<GameObjectBundle> ();
		this.fx = gob.ShootFire;

		StartCoroutine("shoot");
	}

	IEnumerator shoot(){
		yield return new WaitForSeconds (this.delayToStart);
		while(true){
			
			if (this.allowShoot) {

				GameObject fx = Instantiate (
					this.fx,
					this.transform.position,
					this.transform.parent.transform.rotation
				);

				GameObject p = Instantiate (
					this.projectile,
					this.transform.position,
					this.transform.parent.transform.rotation
				);

				Destroy (fx, 0.8f);
				p.GetComponent<Projectile> ().setDirection (this.transform.forward);
				p.transform.SetParent (this.mainCamera);
				this.counter++;
			}

			if (this.counter >= this.sequenceShoots) {
				this.counter = 0;
				yield return new WaitForSeconds (this.timer);
			}
			else {
				yield return new WaitForSeconds (this.sequenceTimer);
			}
		}
	}
}
