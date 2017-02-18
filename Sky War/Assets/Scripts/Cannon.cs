﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

	public GameObject projectile; 
	public float timer = 1f;
	public float delayToStart = 0f;
	public bool allowShoot = true;
	public float posY;

	void Start () {
		this.transform.position = new Vector3 (
			this.transform.position.x,
			this.transform.position.y + (posY - this.transform.position.y),
			this.transform.position.z
		);

		StartCoroutine("shoot");
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
			}

			yield return new WaitForSeconds (this.timer);
		}
	}
}
