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

    private void OnTriggerStay(Collider other)
    {   
        if(Input.GetKeyDown(KeyCode.P)){
			player.SetActive(false);
			cameraMae.SetActive(true);
			pd.Play();
		}
    }
}
