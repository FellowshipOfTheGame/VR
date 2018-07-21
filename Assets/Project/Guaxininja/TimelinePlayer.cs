using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelinePlayer : MonoBehaviour {
    
    
    public PlayableDirector pd;
    public PlayState currstate;

    //player
    public GameObject Player;
    public bool lockplayer;

    //camera
    public GameObject Camera;
    void Start () {
        currstate = pd.state;
	}
	
	
	void Update () {
        CheckState();
        LockPlayer();
	}
    private void CheckState()
    {
        if (pd.state==PlayState.Playing && currstate!=pd.state)
        {
            Debug.Log("rodando");
            currstate = pd.state;
        }
        else if (pd.state == PlayState.Paused && currstate!=pd.state)
        {
            Debug.Log("pausado");
            currstate = pd.state;
        }
    }
    private void LockPlayer()
    {
        if (lockplayer == true)
        {
            if (currstate == PlayState.Playing)
                
            {
                Camera.SetActive(true);
                Player.SetActive(false);
            }
            else if (currstate == PlayState.Paused)
            {
                Player.SetActive(true);
                Camera.SetActive(false);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            pd.Play();
        }        
    }

   
}
