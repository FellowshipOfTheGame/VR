using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TercCena : MonoBehaviour {

	public GameObject player;
	public GameObject cutScenes;
	public GameObject lixeiraCut;
	bool hasPlayed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasPlayed && isNear()){
			if(lixeiraCut.GetComponent<LixeiraCutscene>().CanPlayScene3()){
				cutScenes.GetComponent<CutscenePlayer>().StartCutscene(3);
				hasPlayed = true;
			}
		}
	}

	bool isNear(){
        Vector3 playerPos = player.transform.position;
        Vector3 myPos = transform.position;

        if(Vector3.Distance(myPos, playerPos) < 10){
            return true;
        } else return false;
    }
}
