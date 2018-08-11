using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyController : MonoBehaviour {

    public bool isOn;
    public GameObject _cutscene;

    // Use this for initialization
    void Start () {
        isOn = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.K))
        {
            turnOn();
        }
	}

    void PowerSwitch()
    {
        isOn = !isOn;
    }

    public void turnOn()
    {
        _cutscene.GetComponent<LixeiraCutscene>().PlaySceneOne();
        isOn = true;
    }

    public bool IsOn()
    {
        return isOn;
    }
}
