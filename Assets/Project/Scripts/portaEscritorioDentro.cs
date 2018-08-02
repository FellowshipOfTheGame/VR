using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portaEscritorioDentro : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetButtonDown("Interact1")){
			Enter();
		}
	}

	void Enter(){
		SceneManager.UnloadSceneAsync ("Escritorio");
		player.transform.GetChild(0).gameObject.SetActive(false);
	}
}
