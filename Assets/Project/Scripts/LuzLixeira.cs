using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzLixeira : MonoBehaviour {
	public GameObject power;
    private EnergyController control;
	private Light luz;

    // Use this for initialization
    void Start () {
		control = power.GetComponent<EnergyController>();
		luz = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		luz.enabled = control.IsOn();
	}
}
