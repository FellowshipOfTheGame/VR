﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class LixeiraHide : MonoBehaviour {
	public GameObject player;
	public GameObject camerahide;
    public AudioClip inTrash;
    bool isHiden;

	// Use this for initialization
	void Start () {
		camerahide.SetActive (false);
		isHiden = false;
	}

	public void HideLixeira(){
		player.GetComponent<FirstPersonController> ().enabled = false;
		camerahide.SetActive (true);
		camerahide.transform.eulerAngles = new Vector3 (0, 90, 0);
		isHiden = true;
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(inTrash);
    }
	public void DontHideLixeira(){
		camerahide.transform.eulerAngles = new Vector3 (0, 90, 0);
		camerahide.SetActive (false);
		player.GetComponent<FirstPersonController> ().enabled = true;
		isHiden = false;
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(inTrash);
    }
	// Update is called once per frame
	void Update () {
/* 		if (isHiden == true) {
			if (Input.GetKeyDown(KeyCode.Mouse1)) {
				DontHideLixeira ();
			}
		} */
	}

	public void DisablePlayer(){
		player.GetComponent<FirstPersonController> ().enabled = false;
	}

	public void EnablePlayer(){
		player.GetComponent<FirstPersonController> ().enabled = true;
	}

	public void PlaySound(){
		GetComponent<AudioSource>().PlayOneShot(inTrash);
	}
}
