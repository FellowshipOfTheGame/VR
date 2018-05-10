﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternaBehaviour : MonoBehaviour {

    public GameObject player;
    bool isOnHand = false;
    int dirx = 1;
    float x=0,maxx=15;
    float sx,offset=.04f;
    Vector3 aux;
	public Material mat;

    void Start(){
        changeState("on");
    }

	// Update is called once per frame
	void Update () {
        if(isOnHand){
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)){
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
            if(Input.GetKeyDown(KeyCode.F)){
                changeState("switch");
            }
        }
        else if(Input.GetKeyDown(KeyCode.E)){
            pegarLanterna();
        }
	}
    public void changeState(string s){
        Light l = GetComponent<Light>();
        if(s.Equals("switch")){
            l.enabled = !l.enabled;
        }
        else if(s.Equals("on")){
            l.enabled = true;
        }
        else if(s.Equals("off")){
            l.enabled = false;
        }
    }

    void pegarLanterna(){
        if(!isOnHand){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {    
                if(Vector3.Distance(hit.point, transform.position) < 3){
                    GetComponentInChildren<Renderer>().material = mat;
                    isOnHand = true;
                    transform.parent = player.transform;
                    transform.localPosition = new Vector3(1.7f,.3f,1.7f);
                    transform.localEulerAngles = new Vector3(0f,-9.5f,0f);
                }
            }
        }
    }

}
