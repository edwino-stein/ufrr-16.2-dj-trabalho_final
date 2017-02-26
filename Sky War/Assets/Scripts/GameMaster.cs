using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	public GUISkin scoreSkin;
	public GUISkin comboSkin;

	protected int score = 0;
	protected int combo = 0;
	protected int multiplier = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void updateScore(int score){
		this.score += score * this.multiplier;
		Debug.Log (this.score);
	}

	void incrementCombo(){
		this.combo++;

		if (this.multiplier < 5) {
			if (this.combo % 5 == 0) {
				this.multiplier++;
				Debug.Log ("Mult: " + this.multiplier);
			}
		}
	}

	void resetCombo(){
		this.combo = 0;
		this.multiplier = 1;
	}

	void OnGUI(){
		GUI.skin = this.scoreSkin;
		GUI.Label (new Rect (Screen.width/2 - 75, 10, 150, 25), "Score: "+this.score);

		GUI.skin = this.comboSkin;
		GUI.Label (new Rect (Screen.width - 160, 10, 150, 25), "Combo: "+this.combo);
		GUI.Label (new Rect (Screen.width - 160, 25, 150, 25), "x"+this.multiplier);
	}
}
