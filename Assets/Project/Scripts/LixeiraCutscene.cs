using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LixeiraCutscene : MonoBehaviour {

	public GameObject player;
	public GameObject cutScenes;
	public GameObject camera;
	public GameObject lixeira;
	bool hasPlayed1 = false;
	bool hasPlayed2 = false;
	bool has2finished = false;
	float count = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

			// TODO: reativar o player depois que a cutscene acabar

		if(isNear() && hasPlayed1 && !hasPlayed2){
			if(!cutScenes.GetComponent<CutscenePlayer>().IsPlaying()){

				player.transform.GetChild(0).gameObject.SetActive(false);
				lixeira.GetComponent<LixeiraHide>().DisablePlayer();
				lixeira.GetComponent<LixeiraHide>().PlaySound();
				camera.SetActive(true);

				Debug.Log("Cena 2");
				cutScenes.GetComponent<CutscenePlayer>().StartCutscene(2);
				hasPlayed2 = true;
			}
		}

		if(hasPlayed2 && !has2finished) count += Time.deltaTime;

		if(hasPlayed1 && hasPlayed2 && !has2finished && (count > 5f)){
			if(!cutScenes.GetComponent<CutscenePlayer>().IsPlaying()){

					Debug.Log("Habilitou");
					player.transform.GetChild(0).gameObject.SetActive(true);
					lixeira.GetComponent<LixeiraHide>().EnablePlayer();
					camera.SetActive(false);

					lixeira.GetComponent<LixeiraHide>().PlaySound();

					has2finished = true;
			}
		}
	}

	bool isNear(){
        Vector3 playerPos = player.transform.position;
        Vector3 myPos = transform.position;

        if(Vector3.Distance(myPos, playerPos) < 3){
            return true;
        } else return false;
    }

	public void PlaySceneOne(){
		Debug.Log("Cena 1");
		cutScenes.GetComponent<CutscenePlayer>().StartCutscene(1);
		hasPlayed1 = true;
	}

	public bool CanPlayScene3(){
		return has2finished;
	}
}
