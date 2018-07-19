using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetButtonDown("Interact1") || Input.GetButtonDown("Fire1")){
			// Chamar a proxima cena aqui
			SceneManager.LoadScene("Bosque", LoadSceneMode.Single);  // carrega a cena da intro
		}
	}
}
