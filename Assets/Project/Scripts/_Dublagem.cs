using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Dublagem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		AudioSource[] audios = col.GetComponents<AudioSource> ();
		for (int i = 0; i < audios.Length; i++)
			if (audios [i].clip.name == "Ah, um gatinho")
				audios [i].Play ();

		Destroy (gameObject);
	}
}
