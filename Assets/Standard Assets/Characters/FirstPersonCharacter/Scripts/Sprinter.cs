using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.PostProcessing;

public class Sprinter : MonoBehaviour {
	public PostProcessingProfile profile;
	public bool fadiga;
	public float stamina = 3, maxStamina = 3;
	float walkSpeed, runSpeed;
	public bool IsWalking, cansaco;
	// Use this for initialization
	void Start () {
		walkSpeed = GetComponent<FirstPersonController>().m_WalkSpeed;
		runSpeed = GetComponent<FirstPersonController> ().m_RunSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		IsWalking = GetComponent<FirstPersonController> ().m_IsWalking;
		if (!IsWalking) {
			stamina -= Time.deltaTime;
			if (stamina < 0) {
				fadiga = true;
				cansaco = true;
			}
		}else if(stamina < maxStamina){
			stamina += Time.deltaTime;
			if (stamina > 3) {
				fadiga = false;
			}
			if (stamina > 1.5) {
				cansaco = false;
			}
		}
		if (cansaco) {
			GetComponent<FirstPersonController> ().m_WalkSpeed = 2.5f;
			/*MotionBlurModel.Settings blurSettings = profile.motionBlur.settings;
			blurSettings.frameBlending = 1;
			profile.motionBlur.settings = blurSettings;*/
			profile.motionBlur.enabled = true;
		} else {
			GetComponent<FirstPersonController> ().m_WalkSpeed = 5.0f;
			profile.motionBlur.enabled = false;
		}
	}
}
