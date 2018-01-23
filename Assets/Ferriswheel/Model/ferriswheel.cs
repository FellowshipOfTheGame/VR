using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ferriswheel : MonoBehaviour {

    float speed = 15f;
    bool rotating = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (rotating)
        {
            transform.Rotate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
	}

    void setRotating(bool rotating)
    {
        this.rotating = rotating;
    }
}
