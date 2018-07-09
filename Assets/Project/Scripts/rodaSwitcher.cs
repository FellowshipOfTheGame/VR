using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rodaSwitcher : MonoBehaviour {

	private bool isOn;
	public GameObject power;
	private EnergyController control;

	// Use this for initialization
	void Start () {
		control = power.GetComponent<EnergyController>();
		isOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetButtonDown("Interact1")){
			switch (isOn){
				case true:
					Switch();
					break;
				case false:
					if(control.IsOn()) Switch();
					break;
				default:
					break;				
			}
		}
	}

    void Switch()
    {
        isOn = !isOn;
    }
	public bool IsOn()
    {
        return isOn;
    }
}
