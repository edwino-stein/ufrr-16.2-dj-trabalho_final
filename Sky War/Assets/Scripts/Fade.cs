using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

	public bool startOnLevelWasLoaded = false;
	public Texture2D texture;
	public float speed = 0.8f;

	protected int drawDepth = -1000;
	protected float alpha = 1.0f;
	protected int dir = -1;

	void OnGUI(){
		this.alpha += this.dir * this.speed * Time.deltaTime;
		this.alpha = Mathf.Clamp01 (this.alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, this.alpha);
		GUI.depth = this.drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), this.texture);
	}

	public float startFade(int dir){
		this.dir = dir;
		return this.speed;
	}

	void OnLevelFinishedLoading(){
		if(this.startOnLevelWasLoaded){
			this.startFade (-1);
		}
	}
}
