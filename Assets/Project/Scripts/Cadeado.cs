using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cadeado : MonoBehaviour {

	public GameObject chave;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetButtonDown("Interact1")){
			if (chave.GetComponent<Chave>().PlayerHas()){
				//Destroy(transform.gameObject);
				Open();
			}
		}
	}

	private void Open(){
		transform.GetChild(1).gameObject.transform.Rotate(0, -70f, 0, Space.Self);
	}
}
