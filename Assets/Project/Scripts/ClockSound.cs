using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockSound : MonoBehaviour {
    public GameObject TowerClock;
    public AudioClip tictac;    

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (TowerClock.GetComponent<_Puzzle2Controller>().hasEnergy())
        {
            GetComponent<AudioSource>().PlayOneShot(tictac);
            this.enabled = false;
        }
	}
}
