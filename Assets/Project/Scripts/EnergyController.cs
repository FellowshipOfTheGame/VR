using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyController : MonoBehaviour {

    public bool isOn;

    // Use this for initialization
    void Start () {
        isOn = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.G) || Input.GetButtonDown("Interact3"))
        {
            //PowerSwitch();
        }
	}

    void PowerSwitch()
    {
        isOn = !isOn;
    }

    public void turnOn()
    {
        isOn = true;
    }

    public bool IsOn()
    {
        return isOn;
    }
}
