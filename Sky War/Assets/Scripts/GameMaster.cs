using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	public const int GAME_BEGIN = 0;
	public const int GAME_RUNNIG = 1;
	public const int GAME_GAMEOVER = 2;
	public const int GAME_END = 3;

	public static int gameState = 0;
	public static int playerScore = 0;

	public GUISkin scoreSkin;
	public GUISkin comboSkin;

	protected int score = 0;
	protected int combo = 0;
	protected int multiplier = 1;

	protected bool isPaused = false;

	void Start () {
		GameMaster.gameState = GameMaster.GAME_RUNNIG;
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

	public IEnumerator onBossDie(){
		Debug.Log ("O Boss Morreu");
		yield return new WaitForSeconds (10);
		Debug.Log ("Fim de jogo");
		GameMaster.gameState = GameMaster.GAME_END;
		GameMaster.playerScore = this.score;
		float t = this.GetComponent<Fade> ().startFade (1);
		yield return new WaitForSeconds (t);
		Application.LoadLevel ("Menu");
	}

	public IEnumerator onPlayerDie(){
		Debug.Log ("player morreu");

		GameMaster.gameState = GAME_GAMEOVER;
		GameObject player = GameObject.Find ("Player");
		Destroy (player, 2f);
		yield return new WaitForSeconds (4f);
		float t = this.GetComponent<Fade> ().startFade (1);
		yield return new WaitForSeconds (t);
		Application.LoadLevel ("Menu");
	}

	void OnGUI(){
		GUI.skin = this.scoreSkin;

		if (this.isPaused) {
			GUI.Label (new Rect (Screen.width/2 - 75, Screen.height/2 - 12.5f, 150, 25), "Pause");
			if (GUI.Button (new Rect (Screen.width/2 - 75, Screen.height/2 + 40, 150, 40), "Reinicar")) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}

		GUI.Label (new Rect (Screen.width/2 - 75, 10, 150, 25), "Score: "+this.score);

		GUI.skin = this.comboSkin;
		GUI.Label (new Rect (Screen.width - 160, 10, 150, 25), "Combo: "+this.combo);
		GUI.Label (new Rect (Screen.width - 160, 25, 150, 25), "x"+this.multiplier);
	}

	void setPause(bool pause){
		this.isPaused = pause;
		GameObject boss = GameObject.FindWithTag ("Boss");
		if (boss) {
			boss.SendMessage ("setPause", pause);
		}
	}
}
