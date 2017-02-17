using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour {
	
	public GameObject subject;
	public string projectileTag = "Projectile";
	public float maxLife = 100f;
	public float colliderHeight = 0;

	protected float life;

	public Vector2 healthBarPos;
	protected GameObject healthBar;
	protected float healthBarVisibilityTime = 0f;
	protected float healthBarMaxVisibilityTime = 2f;

	protected BoxCollider col;

	void Start () {

		this.life = this.maxLife;

		GameObjectBundle gob = GameObject.Find ("GameObjectBundle").GetComponent<GameObjectBundle> ();
		this.col = (BoxCollider) this.GetComponent<Collider>();

		this.healthBar = Instantiate (
			gob.HealthBar,
			new Vector3(
				this.transform.position.x + this.healthBarPos.x,
				gob.HealthBar.transform.position.y,
				this.transform.position.z  + this.healthBarPos.y
			),
			new Quaternion()
		);
		this.healthBar.transform.rotation = gob.HealthBar.transform.rotation;
		this.healthBar.transform.SetParent (this.transform);
		this.healthBar.name = this.transform.name + "_" + gob.HealthBar.name;
		this.healthBarVisibilityTime = 0f;
		StartCoroutine("healthBarFade");
	}

	void Update(){
		col.center = new Vector3(0, (colliderHeight - this.transform.position.y)/(col.bounds.size.y/1), 0);
	}

	void OnTriggerEnter(Collider other) {
		
		if (other.tag == this.projectileTag) {
			
			Projectile p = other.gameObject.GetComponent<Projectile> ();

			if (p.target == this.tag) {
				
				this.life -= p.damage;
				this.updateHealthBar ();
				Destroy(other.gameObject);

				if (this.life <= 0) Destroy(this.subject);
			}
		}
	}

	void updateHealthBar(){
		Transform bar = this.healthBar.transform.FindChild ("HbBar");
		bar.localScale = new Vector3 (this.life / this.maxLife, bar.localScale.y, bar.localScale.z);
		this.healthBarVisibilityTime = this.healthBarMaxVisibilityTime;
	}

	IEnumerator healthBarFade(){
		float pass = 0.1f;

		while(true){
			
			if (this.healthBarVisibilityTime > 0) {
				this.healthBarVisibilityTime -= pass;
				this.healthBar.SetActive (true);
			}
			else {
				this.healthBarVisibilityTime = 0;
				this.healthBar.SetActive (false);
			}

			yield return new WaitForSeconds(pass);
		}
	}
}
