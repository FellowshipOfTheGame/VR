using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSair : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0)){		// TO DO: adicionar a tecla do controle do VR Box
			// Sair do jogo
			Application.Quit();
		}
	}
}
