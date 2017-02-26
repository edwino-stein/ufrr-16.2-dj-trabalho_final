using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeCycle : MonoBehaviour {
	
	public int scoreForKill = 1;
	public bool lookAtPlayer = true;

	protected float explosionTime = 2f;
	protected GameObject gm;

	void Start () {
		this.gm = GameObject.Find ("GameMaster");
		GameObjectBundle gob = this.gm.GetComponent<GameObjectBundle> ();
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
			this.gm.SendMessage ("updateScore", this.scoreForKill);
			this.gm.SendMessage ("incrementCombo");
			this.explode (subject.transform);
			Destroy (subject, this.explosionTime/4);

		} else if (subject.tag == "Boss") {
			Debug.Log (target.name + " morreu: Ganhou " + this.scoreForKill + " Pontos");
			this.explode (target.transform);
			Destroy (target, this.explosionTime/4);
			subject.SendMessage ("onBossPieceDie", target);
		}
	}

	public void onSubjectTakeDamage(float damage){
		return;
	}

	public void explode(Transform subject){
		GameObjectBundle gob = this.gm.GetComponent<GameObjectBundle> ();
		GameObject explosion = gob.Explosion;
		GameObject e = Instantiate (explosion, subject.position, subject.rotation);
		Destroy (e, this.explosionTime);
	}
}
