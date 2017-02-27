using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	public GUISkin skin;
	public GUISkin titleSkin;

	void OnGUI(){

		if (GameMaster.gameState == GameMaster.GAME_BEGIN) {
			
			GUI.skin = this.titleSkin;
			GUI.Label (new Rect (Screen.width / 2 - 150, 50, 300, 50), "Sky Wars");

			GUI.skin = this.skin;
			GUI.Label (new Rect (Screen.width - 225, Screen.height / 2 + 60, 150, 50), "Criado por Edwino Stein");
			if (GUI.Button (new Rect (Screen.width - 200, Screen.height / 2, 100, 50), "Iniciar")) {
				Application.LoadLevel ("Main");
			}
		}
	}

}
