using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

	public GameObject projectile;
	public float timer = 1f;
	public float delayToStart = 0f;
	public bool allowShoot = true;
	public float posY;

	public bool allowFx = true;
	protected Transform mainCamera;
	protected GameObject fx;

	void Start () {
		this.transform.position = new Vector3 (
			this.transform.position.x,
			this.transform.position.y + (posY - this.transform.position.y),
			this.transform.position.z
		);

		this.mainCamera = Camera.main.transform;
		GameObjectBundle gob = GameObject.Find ("GameMaster").GetComponent<GameObjectBundle> ();
		this.fx = gob.ShootFire;

		if (this.allowFx) {
			StartCoroutine("shootFx");
		}
		else {
			StartCoroutine("shoot");
		}

	}

	IEnumerator shootFx(){
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

				p.GetComponent<Projectile> ().setDirection (this.transform.forward);
				p.transform.SetParent (this.mainCamera);

				Destroy (fx, 0.8f);
			}

			yield return new WaitForSeconds (this.timer);
		}
	}

	IEnumerator shoot(){
		yield return new WaitForSeconds (this.delayToStart);
		while(true){

			if (this.allowShoot) {

				GameObject p = Instantiate (
					this.projectile,
					this.transform.position,
					this.transform.parent.transform.rotation
				);

				p.GetComponent<Projectile> ().setDirection (this.transform.forward);
				p.transform.SetParent (this.mainCamera);
			}

			yield return new WaitForSeconds (this.timer);
		}
	}
}
