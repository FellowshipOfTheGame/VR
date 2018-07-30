using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class CutscenePlayer : MonoBehaviour {
   
    //cutscene properties
    public bool startplaying;
    public PlayableDirector[] pdList;
    public int currscene;
    private PlayableDirector pd;
    public PlayState currstate;
    
    //player
    public GameObject Player;
    public bool lockplayer;

   
   
    void Start () {
        CheckCutscene();
        currstate = pd.state;
    
	}
	
	void Update () {
        if (startplaying == true && currstate == PlayState.Paused)
            {
                startplaying = false;
                pd.Play();
            }
        else if (Input.GetKey(KeyCode.E) && currstate==PlayState.Paused)
        {
            startplaying = true;
        }
        CheckState();
        CheckCutscene();
	}
    private void CheckCutscene()
    {
        pd = pdList[currscene-1];
    }
    private void CheckState()
    {
        if (pd.state == PlayState.Playing && currstate != pd.state)
        {
            Debug.Log("rodando");
            currstate = pd.state;
        }
        else if (pd.state == PlayState.Paused && currstate != pd.state)
        {
            Debug.Log("pausado");
            currstate = pd.state;
        }

    }
 
    
}
