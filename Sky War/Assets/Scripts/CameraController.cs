using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	public bool moviment = true;
	public float speed = 1f;

	public float borderWidth = 2f;
	public GameObject border;
	public GameObject starterBorder;
	public GameObject destroyerBorder;

	protected GameObject rightBorder;
	protected GameObject leftBorder;
	protected GameObject bottomBorder;

	public Vector2 InitialPos;

	public GameObject bossSenaryTaling;
	protected bool enableBossSenaryTaling = false;
	protected float sizeBossSenaryTaling = 500;
	protected float nextPosBossSenaryTaling = 0;
	protected float bossSenaryTalingY = -1;
	void Start(){
		
		float y = Camera.main.orthographicSize;
		float x = y * Screen.width / Screen.height;
		float width = (x + this.borderWidth) * 2;
		float height = y * 2 ;
		float padding = this.borderWidth/2;

		this.rightBorder = Instantiate(this.border, new Vector3 (x + padding, 0, 0), this.border.transform.rotation);
		this.rightBorder.name = "rightBorder";
		this.rightBorder.transform.localScale = new Vector3(this.borderWidth, this.borderWidth, height);
		this.rightBorder.transform.SetParent(this.transform);

		this.leftBorder = Instantiate(this.border, new Vector3 (-x - padding, 0, 0), this.border.transform.rotation);
		this.leftBorder.name = "leftBorder";
		this.leftBorder.transform.localScale = new Vector3(this.borderWidth, this.borderWidth, height);
		this.leftBorder.transform.SetParent(this.transform);

		this.bottomBorder = Instantiate(this.border, new Vector3 (0, 0, -y - padding), this.border.transform.rotation);
		this.bottomBorder.name = "bottomBorder";
		this.bottomBorder.transform.localScale = new Vector3(width, this.borderWidth, this.borderWidth);
		this.bottomBorder.transform.SetParent(this.transform);

		this.border.transform.position = new Vector3 (0, 0, y + padding); 
		this.border.name = "topBorder";
		this.border.transform.localScale = new Vector3(width, this.borderWidth, this.borderWidth);
		this.border.transform.SetParent(this.transform);

		this.starterBorder.transform.position = new Vector3 (0, 0, y + padding*10); 
		this.starterBorder.transform.localScale = new Vector3(width * 1.5f, this.borderWidth * 10, this.borderWidth);
		this.starterBorder.transform.SetParent(this.transform);

		this.destroyerBorder.transform.position = new Vector3 (0, 0, - y - padding*10); 
		this.destroyerBorder.transform.localScale = new Vector3(width * 1.5f, this.borderWidth * 10, this.borderWidth);
		this.destroyerBorder.transform.SetParent(this.transform);

		this.player.transform.SetParent(this.transform);

		this.transform.position = new Vector3(
			this.InitialPos.x,
			this.transform.position.y,
			this.InitialPos.y
		);
	}

	void Update () {
		Vector3 position = this.transform.position;

		if (moviment) {
			position.z += speed;
			this.transform.position = position;
		}

		if (this.enableBossSenaryTaling) {
			if (this.nextPosBossSenaryTaling <= position.z + 50) {
				Debug.Log ("BossSenaryTaling");
				Instantiate (
					this.bossSenaryTaling,
					new Vector3 (
						this.bossSenaryTaling.transform.position.x,
						this.bossSenaryTaling.transform.position.y + this.bossSenaryTalingY,
						this.nextPosBossSenaryTaling + this.sizeBossSenaryTaling*1.3f
					),
					this.bossSenaryTaling.transform.rotation
				);

				this.nextPosBossSenaryTaling = this.transform.position.z + this.sizeBossSenaryTaling*1.3f;
				this.bossSenaryTalingY = this.bossSenaryTalingY > 0 ? -1 : 1;
			}
		}
	}

	void onBossSpawn(){
		this.enableBossSenaryTaling = true;
		this.nextPosBossSenaryTaling = this.transform.position.z + this.sizeBossSenaryTaling;
	}
}
