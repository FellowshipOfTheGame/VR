using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnabelleLaug : MonoBehaviour {

    public GameObject chave;
    public AudioClip laugh;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (chave.GetComponent<Chave>().PlayerHas())
        {
            //Destroy(transform.gameObject);
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(laugh);
            GetComponent<AnabelleLaug>().enabled = false;
        }
    }
}
