using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portaEscritorio : MonoBehaviour {

	public GameObject relogio;
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetButtonDown("Interact1")){
			//if (relogio.GetComponent<_Puzzle2Controller>().isFinished())
				Enter();
		}
	}

	void Enter(){
		StartCoroutine(LoadYourAsyncScene());
		//AsyncOperation async = SceneManager.LoadSceneAsync ("Escritorio", LoadSceneMode.Additive);
	}

	IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Escritorio", LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
		player.SetActive(false);
    }

}
