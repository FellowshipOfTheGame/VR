using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaDaFonte : MonoBehaviour {
	
	private GameObject estatua;
	public GameObject fonte;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.J)){ // debug
			trocaParafonte();
		}
	}


	void trocaParafonte(){
		GetComponent<MeshFilter>().mesh = fonte.GetComponent<MeshFilter>().mesh;
		// GetComponent<MeshCollider>().sharedMesh = fonte.GetComponent<MeshCollider>().sharedMesh;
		transform.position += new Vector3(2,2,2);
	}

}