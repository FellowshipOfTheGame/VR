using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingArrow : MonoBehaviour {

    private float count = 0f;
    private GameObject scene = null;
    private GameObject ui = null;

    // Use this for initialization
    void Start () {

        //StartCoroutine(LoadYourAsyncScene());     // Used when this is a loading screen Scene
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, 5));

        // Used when this is a loading screen GameObject
        count += Time.deltaTime;
        CheckTime();
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

    public void CheckTime()
    {
        if (count > 5f)
        {
            Destroy(this);
        }
    }
}
