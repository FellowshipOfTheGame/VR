using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    float f;
    float s;
	int flag = 0;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;	
	}
	
	// Update is called once per frame
	void Update () {
		f = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        s = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(s,0,f);
        if (Input.GetKeyDown("escape")){
			if(flag == 0){
				Cursor.lockState = CursorLockMode.None;
				flag = 1;
			}
			else{
				Cursor.lockState = CursorLockMode.Locked;
				flag = 0;
			}
        }
	}
}
