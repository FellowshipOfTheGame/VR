using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingArrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(LoadYourAsyncScene());
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, 5));
	}

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background at the same time as the current Scene.
        //This is particularly good for creating loading screens. You could also load the Scene by build //number.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Centro1");

        //Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            Debug.Log("async.progress: " + asyncLoad.progress);
            yield return null;
        }
    }
}
