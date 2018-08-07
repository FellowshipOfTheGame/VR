using System.Collections;
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
    public AudioClip liga;
    public AudioClip desliga;
    public AudioClip pega;

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
                Light l = GetComponent<Light>();
                if (l.enabled)
                    GetComponent<AudioSource>().PlayOneShot(liga);
                else
                    GetComponent<AudioSource>().PlayOneShot(desliga);
            }
        }
        else{
            pegarLanterna();
        }
/*         else if(Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Interact1")){
            pegarLanterna();
            GetComponent<AudioSource>().PlayOneShot(liga);
        } */
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
            if(isNear()){
                GetComponent<AudioSource>().PlayOneShot(pega);
                isOnHand = true;
                transform.parent = player.transform;
                //transform.localPosition = new Vector3(1.9f,-0.8f,0.4f);
                transform.localPosition = new Vector3(1.9f,-0.66f,-1.9f);
                //transform.localEulerAngles = new Vector3(0f,-21f,0f);
                transform.localEulerAngles = new Vector3(0f,-15f,0f);
            }
        }
    }

    bool isNear(){
        Vector3 playerPos = player.transform.position;
        Vector3 myPos = transform.position;

        if(Vector3.Distance(myPos, playerPos) < 3){
            return true;
        } else return false;
    }

/*     void pegarLanterna(){
        if(!isOnHand){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {    
                if(Vector3.Distance(hit.point, transform.position) < 3){
                    GetComponentInChildren<Renderer>().material = mat;
                    isOnHand = true;
                    transform.parent = player.transform;
                    transform.localPosition = new Vector3(1.9f,-0.8f,0.4f);
                    transform.localEulerAngles = new Vector3(0f,-21f,0f);
                }
            }
        }
    } */

}
