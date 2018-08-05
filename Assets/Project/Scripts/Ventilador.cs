using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilador : MonoBehaviour {

	bool power;
	public GameObject PowerController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		try{
			power = PowerController.GetComponent<EnergyController>().IsOn();
			transform.GetChild(0).gameObject.SetActive(power);
        	transform.GetChild(1).gameObject.SetActive(power);
        	transform.GetChild(2).gameObject.SetActive(power);
		} catch{
			Debug.Log("Erro em apagar/acender luz do ventilador");
		}
	}
}
