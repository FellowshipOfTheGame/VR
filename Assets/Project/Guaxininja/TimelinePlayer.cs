using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelinePlayer : MonoBehaviour {
    
	public GameObject cameraMae, player;
    
    public PlayableDirector pd;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
<<<<<<< HEAD
    private void OnTriggerEnter(Collider other)
    {   
        pd.Play();
        Debug.Log("cabou");
=======
>>>>>>> 3ee83be89325474f603c9703d74ae895c3a0bdc5

    private void OnTriggerStay(Collider other)
    {   
        if(Input.GetKeyDown(KeyCode.P)){
			player.SetActive(false);
			cameraMae.SetActive(true);
			pd.Play();
		}
    }
}
