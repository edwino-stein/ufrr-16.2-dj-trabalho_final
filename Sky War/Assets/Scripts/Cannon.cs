using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

	public GameObject projectile; 
	public float timer = 1f;
	public bool allowShoot = true;

	void Start () {
		StartCoroutine("shoot");
	}

	IEnumerator shoot(){
		while(this.allowShoot){
			GameObject p = Instantiate(this.projectile);
			p.transform.position = this.transform.position;
			yield return new WaitForSeconds(this.timer);
		}
	}
}
