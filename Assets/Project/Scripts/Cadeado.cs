using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cadeado : MonoBehaviour {

	public GameObject chave;
	private bool abriu;

	// Use this for initialization
	void Start () {
		abriu = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetButtonDown("Interact1")){
			if (chave.GetComponent<Chave>().PlayerHas()){
                //Destroy(transform.gameObject);
                GetComponent<AudioSource>().Play();
				Open();
			}
		}
	}

	private void Open(){
		if (!abriu){
			transform.GetChild(1).gameObject.transform.Rotate(0, -75f, 0, Space.Self);
			abriu = true;
		}
	}
}
