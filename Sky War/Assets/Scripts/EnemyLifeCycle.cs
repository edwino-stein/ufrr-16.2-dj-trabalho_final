using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeCycle : MonoBehaviour {
	
	public int scoreForKill = 1;
	public bool lookAtPlayer = true;

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
	}

	public void onSubjectDie(GameObject target){

		DamageController dc = target.GetComponent<DamageController> ();
		if (dc == null) {
			return;
		}

		GameObject subject = dc.subject;

		if (subject.tag == "Enemy") {
			Debug.Log (subject.name + " morreu: Ganhou " + this.scoreForKill + " Pontos");
			Destroy (target);
		} else if (subject.tag == "Boss") {
			Debug.Log (target.name + " morreu: Ganhou " + this.scoreForKill + " Pontos");
			subject.SendMessage ("onBossPieceDie", target);
		}
	}
}
