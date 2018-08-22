using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastKey : MonoBehaviour {

	public GameObject chave1;
	public GameObject chave2;
	public GameObject chave3;
	private bool gotAll = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!gotAll){
			if(chave1.GetComponent<Chave>().PlayerHas() && 
				chave2.GetComponent<Chave>().PlayerHas() && 
					chave3.GetComponent<Chave>().PlayerHas()){
						GetComponent<AudioSource>().Play();
						gotAll = true;
					}
		}
	}
}
