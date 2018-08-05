using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour {

    //Volume: 1~0
    //Magnetude
    public AudioClip cai;
	void OnCollisionEnter(Collision col){
		if(col.relativeVelocity.magnitude >= 5){
			GetComponent<AudioSource>().PlayOneShot(cai);
		}
	}
}
