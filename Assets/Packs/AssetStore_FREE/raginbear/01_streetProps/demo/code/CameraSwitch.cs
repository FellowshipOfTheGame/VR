using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

    public GameObject cam1;
    public GameObject cam2;

    public void Toggle()
    {
        if(cam1.activeSelf)
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }

        else
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
        }
    }
}
