using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private bool canLoad;

    private GameObject player = null;
    private bool achou = false;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("FPSController");
        canLoad = false;
        StartCoroutine(LoadYourAsyncScene());
    }

    // Update is called once per frame
    void Update()
    {
        if (!achou)
        {
            if ((player = GameObject.Find("FPSController")) != null)
            {
                achou = true;
                Debug.Log("Achou o player!");
            }
        }
        else
        {
            CheckHeight();
        }

        /*
        if (Input.GetKeyDown(KeyCode.L))    //loading test
        {
            AuthorizeLoad();
        }
        */
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background at the same time as the current Scene.
        //This is particularly good for creating loading screens. You could also load the Scene by build //number.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Centro1");
        Debug.Log("Load Started...");

        //Wait for a confirmation to then load the scene
        asyncLoad.allowSceneActivation = false;

        //Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone && !canLoad)
        {
            //Debug.Log("async.progress: " + asyncLoad.progress);

            if (asyncLoad.isDone)
            {
                Debug.Log("Scene Loaded");
            }

            yield return null;
        }

        //Load scene when authorized 
        asyncLoad.allowSceneActivation = true;
        yield return asyncLoad;
    }

    public void AuthorizeLoad()
    {
        canLoad = true;
        Debug.Log("Load authorized");
    }

    public void CheckHeight()
    {
        Debug.Log(player.transform.position.y);
        if (player.transform.position.y < 6)
        {
            AuthorizeLoad();
        }
    }
}
