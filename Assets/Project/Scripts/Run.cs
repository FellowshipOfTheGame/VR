using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour {

    int dirx = 1;
    float x=0,maxx=15;
    float sx,offset=.04f;
    Vector3 aux;
	
    bool isOn;

    void Start () {
        isOn = false;
        if(transform.parent.gameObject.name == "EstatuaVon"){
            isOn = true;
        }
    }

	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.F)){
            isOn = !isOn;
        }

        GetComponent<Light> ().enabled = isOn;
        
        if (Input.GetKey(KeyCode.LeftShift)){
            if (dirx == 1){
                aux = new Vector3(offset,0f,0f);
                transform.localPosition += aux;
                x++;
                if(x == maxx){
                    dirx = 0;
                }
            }
            else{
                aux = new Vector3(-offset, 0f, 0f);
                transform.localPosition += aux;
                x--;
                if (-x == maxx){
                    dirx = 1;
                }
            }
        }
        else{
            aux = new Vector3 (-x * offset, 0f, 0f);
            x = 0;
            transform.localPosition += aux;
        }
	}
}
