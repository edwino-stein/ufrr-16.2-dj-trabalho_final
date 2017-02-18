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
	}

	void Update () {
		if (moviment) {
			Vector3 position = this.transform.position;
			position.z += speed;
			this.transform.position = position;
		}
	}
}
