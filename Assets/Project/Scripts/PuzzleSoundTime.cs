using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSoundTime : MonoBehaviour {
    public double time;
    public GameObject Puzzle1;
	// Use this for initialization
	void Start () {
        time = 5;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;

        if(time <= 0)
        {
            GetComponent<AudioSource>().Stop();
        }
	}
}
