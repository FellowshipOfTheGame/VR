using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChooser : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Application.platform == RuntimePlatform.Android){
			// se o jogo estiver rodando em android:
			try{
				transform.GetChild(0).gameObject.SetActive(true);
			} catch (UnityException e){
				Debug.Log(e);
				Application.Quit();
			}
		} else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor ||
						Application.platform == RuntimePlatform.LinuxEditor ){
			// se o jogo estiver rodando no windows ou no editor
			try{
				transform.GetChild(1).gameObject.SetActive(true);
			} catch (UnityException e){
				Debug.Log(e);
				Application.Quit();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
