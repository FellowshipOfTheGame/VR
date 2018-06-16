using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Note : MonoBehaviour {
	public Image noteImage;
	public AudioClip pickupSound;
	public AudioClip putawaySound;
    public AudioClip fallingSound;
	public GameObject player;
	public GameObject playerAnd;
    public GameObject vio;

    public bool isReady = false;

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

        //checar se eh o ultimo note
        print(noteImage.name);
        if (noteImage.name == "Pag8_Image")
        {
			if (Application.platform == RuntimePlatform.Android){
				playerAnd.GetComponent<FirstPersonController>().isClear = true;
			}else{
				player.GetComponent<FirstPersonController>().isClear = true;
			}
            
            isReady = true;
        }
	}

	public void HideNoteImage(){
        noteImage.enabled = false;
		GetComponent<AudioSource> ().PlayOneShot (putawaySound);
		if (Application.platform == RuntimePlatform.Android){
			playerAnd.GetComponent<FirstPersonController> ().enabled = true;
		}else{
			player.GetComponent<FirstPersonController> ().enabled = true;
		}
        //note.GetComponent<MeshRenderer> ().enabled = true;

        //cair depois de ler o ultimo note
        if (isReady)
        {
			if (Application.platform == RuntimePlatform.Android){
				playerAnd.GetComponent<FirstPersonController>().Cair();
			} else{
				player.GetComponent<FirstPersonController>().Cair();
			}
            
            vio.GetComponent<AudioSource>().Stop();
            vio.GetComponent<AudioSource>().PlayOneShot(fallingSound);
        }
    }

	void Update(){
		if (noteImage.enabled == true) {
			if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetButtonDown("Interact1")) {
				HideNoteImage ();

			}
		}
	}
}
