using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chave : MonoBehaviour {

	private bool playerHas;

	// Use this for initialization
	void Start () {
		playerHas = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetButtonDown("Interact1")){
            GetComponent<AudioSource>().Play();
            GetKey();
		}
	}

	private void GetKey(){
		playerHas = true;
		transform.localScale = new Vector3(0, 0, 0);
	}

	public bool PlayerHas(){
		return playerHas;
	}
}
