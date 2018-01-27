using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Note : MonoBehaviour {
	public Image noteImage;
	public AudioClip pickupSound;
	public AudioClip putawaySound;
	public GameObject player;
	//public GameObject note;
	// Use this for initialization
	void Start () {
		noteImage.enabled = false;
	}
	
	public void ShowNoteImage(){
		noteImage.enabled = true;
		GetComponent<AudioSource> ().PlayOneShot (pickupSound);
		player.GetComponent<FirstPersonController> ().enabled = false;
		//note.GetComponent<MeshRenderer> ().enabled = false;
	}

	public void HideNoteImage(){
		noteImage.enabled = false;
		GetComponent<AudioSource> ().PlayOneShot (putawaySound);
		player.GetComponent<FirstPersonController> ().enabled = true;
		print ("oi");
		//note.GetComponent<MeshRenderer> ().enabled = true;
	}

	void Update(){
		if (noteImage.enabled == true) {
			if (Input.GetKeyDown ("joystick button 1") || Input.GetKeyDown(KeyCode.Mouse1)) {
				HideNoteImage ();

			}
		}
	}
}
