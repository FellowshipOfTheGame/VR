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
    //public bool lockplayer;
    public GameObject[] CutsceneObjects;
   
    void Start () {
        CheckCutscene();
        currstate = pd.state;
        
	}
	
	void Update () {
        CheckState();
        CheckCutscene();
        if (startplaying == true && currstate == PlayState.Paused)
            {
                startplaying = false;
                pd.Play();
            }
        else if (Input.GetKey(KeyCode.C) && currstate==PlayState.Paused)
        {
            startplaying = true;
        }
        DestroyCutsceneObjects();
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
    private void DestroyCutsceneObjects()
    {
        if (currstate == PlayState.Paused)
        {
            CutsceneObjects[0].SetActive(false);
            CutsceneObjects[1].SetActive(false);
            // CutsceneObjects[2].SetActive(false);
            // CutsceneObjects[3].SetActive(false);
        }
        else if(currstate == PlayState.Playing)
        {
            CutsceneObjects[0].SetActive(true);
            CutsceneObjects[1].SetActive(true);
        }
    }

    public void StartCutscene(int scene){
        this.currscene = scene;
        startplaying = true;
    }

    public bool IsPlaying(){
        if (currstate == PlayState.Paused) return false;
        else return true;
    }
    
}
