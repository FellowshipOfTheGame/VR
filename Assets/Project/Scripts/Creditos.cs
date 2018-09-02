using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour {

	public Vector3 velocity = new Vector3(0.0f, 1.0f, 0.0f);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < 45f) transform.position += velocity*Time.deltaTime;

		if(Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("Menu", LoadSceneMode.Single);  // carrega a cena do menu
	}
}
