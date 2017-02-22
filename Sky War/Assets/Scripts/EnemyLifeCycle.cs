using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeCycle : MonoBehaviour {
	
	public int scoreForKill = 1;
	public bool lookAtPlayer = true;
	public bool allowAttack = true;

	void Start () {

		GameObjectBundle gob = GameObject.Find ("GameObjectBundle").GetComponent<GameObjectBundle> ();
		GameObject player = gob.Player;

		if (this.lookAtPlayer) {
			LookAt lookAt = this.GetComponent<LookAt> ();
			if (lookAt) {
				lookAt.target = player;
				lookAt.freezeY = true;
			}
		}

		if (allowAttack) {
			Transform c = this.transform.FindChild ("Cannon");
			if (c) {
				Cannon cannon = c.GetComponent<Cannon> ();
				cannon.allowShoot = true;
			}
		}
	}

	public void onSubjectDie(GameObject subject){
		Debug.Log (subject.name + " morreu: Ganhou "+this.scoreForKill+" Pontos");
	}
}
