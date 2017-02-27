using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	public GUISkin skin;
	public GUISkin titleSkin;

	void OnGUI(){

		GUI.skin = this.titleSkin;
		GUI.Label (new Rect (Screen.width / 2 - 150, 50, 300, 50), "Sky Wars");

		GUI.skin = this.skin;
		GUI.Label (new Rect (Screen.width/2 - 75, Screen.height - 60, 150, 50), "Criado por Edwino Stein");

		if (GameMaster.gameState == GameMaster.GAME_BEGIN) {
			if (GUI.Button (new Rect (Screen.width - 275, Screen.height/2, 150, 50), "Iniciar")) {
				StartCoroutine("startMainLevel");
			}
		}

		if(GameMaster.gameState == GameMaster.GAME_END){
			
			GUI.Box (new Rect (Screen.width - 325, Screen.height/2 - 50, 250, 100), "");
			GUI.Label (new Rect (Screen.width - 275, Screen.height/2 - 50, 150, 50), "Venceu o jogo!");


			if (GUI.Button (new Rect (Screen.width - 275, Screen.height/2 + 70, 150, 40), "Reinicar")) {
				StartCoroutine("startMainLevel");
			}

			GUI.skin = this.titleSkin;
			GUI.Label (new Rect (Screen.width - 275, Screen.height/2 - 10, 150, 50), ""+GameMaster.playerScore);
		}

		if (GameMaster.gameState == GameMaster.GAME_GAMEOVER) {
			GUI.Box (new Rect (Screen.width - 325, Screen.height/2 - 50, 250, 100), "");
			GUI.Label (new Rect (Screen.width - 275, Screen.height/2 - 50, 150, 50), "Game Over!");


			if (GUI.Button (new Rect (Screen.width - 275, Screen.height/2 + 70, 150, 40), "Reinicar")) {
				StartCoroutine("startMainLevel");
			}

			GUI.skin = this.titleSkin;
			GUI.Label (new Rect (Screen.width - 275, Screen.height/2 - 10, 150, 50), ""+GameMaster.playerScore);
		}
	}

	IEnumerator startMainLevel(){
		float t = this.GetComponent<Fade> ().startFade (1);
		yield return new WaitForSeconds (t);
		Application.LoadLevel ("Main");
	}
}
