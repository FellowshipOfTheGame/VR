using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCreditos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0)){
			// Chamar os creditos aqui
			SceneManager.LoadScene("VonDancing", LoadSceneMode.Single);  // carrega a cena dos creditos
		}
	}
}
