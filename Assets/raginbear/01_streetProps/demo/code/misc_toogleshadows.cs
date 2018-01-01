using UnityEngine;
using System.Collections;

public class misc_toogleshadows : MonoBehaviour {

    public void Toggle()
    {
        Light light = transform.GetComponent<Light>();
        if (light.shadows != LightShadows.None)
        {
            light.shadows = LightShadows.None;
        }
        else
        {

            light.shadows = LightShadows.Soft;

        }
    }
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
