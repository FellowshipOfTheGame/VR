using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzesPalco : MonoBehaviour {

    private float timer = 0f;
    public bool temEnergia;

    public GameObject luz1;
    public GameObject luz2;
    public GameObject luz3;
    public GameObject luz4;
    public GameObject luz5;
    public GameObject luz6;
    public GameObject luz7;

    public GameObject Power;

    public AudioClip Lightson;
    bool once = false;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        /*  // Pisca a cada 1s  
        timer += Time.deltaTime;
		if (timer>1)
        {
            timer = 0f;
            Switch();
        }
        */

        temEnergia = false;
        if(Power != null)
        {
            temEnergia = Power.GetComponent<EnergyController>().IsOn();
        }

        if (temEnergia)
        {
            TurnOn();
            if (!once)
            {
                GetComponent<AudioSource>().PlayOneShot(Lightson);
                once = true;
            }
        }
        else
        {
            once = false;
            TurnOff();
        }
	}

    void Switch()
    {
        luz1.GetComponent<MeshRenderer>().enabled = !luz1.GetComponent<MeshRenderer>().enabled;
        luz2.GetComponent<MeshRenderer>().enabled = !luz2.GetComponent<MeshRenderer>().enabled;
        luz3.GetComponent<MeshRenderer>().enabled = !luz3.GetComponent<MeshRenderer>().enabled;
        luz4.GetComponent<MeshRenderer>().enabled = !luz4.GetComponent<MeshRenderer>().enabled;
        luz5.GetComponent<MeshRenderer>().enabled = !luz5.GetComponent<MeshRenderer>().enabled;
        luz6.GetComponent<MeshRenderer>().enabled = !luz6.GetComponent<MeshRenderer>().enabled;
        luz7.GetComponent<MeshRenderer>().enabled = !luz7.GetComponent<MeshRenderer>().enabled;
    }

    void TurnOff()
    {
        luz1.GetComponent<MeshRenderer>().enabled = false;
        luz2.GetComponent<MeshRenderer>().enabled = false;
        luz3.GetComponent<MeshRenderer>().enabled = false;
        luz4.GetComponent<MeshRenderer>().enabled = false;
        luz5.GetComponent<MeshRenderer>().enabled = false;
        luz6.GetComponent<MeshRenderer>().enabled = false;
        luz7.GetComponent<MeshRenderer>().enabled = false;
    }

    void TurnOn()
    {
        luz1.GetComponent<MeshRenderer>().enabled = true;
        luz2.GetComponent<MeshRenderer>().enabled = true;
        luz3.GetComponent<MeshRenderer>().enabled = true;
        luz4.GetComponent<MeshRenderer>().enabled = true;
        luz5.GetComponent<MeshRenderer>().enabled = true;
        luz6.GetComponent<MeshRenderer>().enabled = true;
        luz7.GetComponent<MeshRenderer>().enabled = true;
    }
}
