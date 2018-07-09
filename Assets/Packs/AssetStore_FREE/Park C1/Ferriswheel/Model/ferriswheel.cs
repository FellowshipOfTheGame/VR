using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ferriswheel : MonoBehaviour {

    float speed = 15f;
    bool rotating = false;

    public GameObject switcher;
    private rodaSwitcher control;

	// Use this for initialization
	void Start () {
		control = switcher.GetComponent<rodaSwitcher>();
	}
	
	// Update is called once per frame
	void Update () {
        setRotating(control.IsOn());

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
