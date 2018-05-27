using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    Light myLight;        // Your light



	float timer = 0f;
    float bigTimer = 0f;

	private bool temSangue;
	private bool trocou;

	public GameObject semSangue;
	public GameObject comSangue;

	// Use this for initialization
	void Start () {
		//semSangue = GameObject.Find("SemSangue");
		//comSangue = GameObject.Find("ComSangue");

		temSangue = false;
		trocou = false;
		myLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
        bigTimer += Time.deltaTime;
        if (bigTimer < 0.9)
        {
            if (timer > 0.1f)
            {
                myLight.enabled = !myLight.enabled;
                timer = 0;
            }
        }
        else	// depois de 0.9 seg piscando
        {
			if(bigTimer < 1){		// apaga a luz e troca os notes
				myLight.enabled = false;
				if (!trocou){
					TrocaNotes();
					trocou = true;
				}
			} else {				// depois de 0.1 seg de luz apagada, acende de novo
				myLight.enabled = true;
				if (bigTimer > 2.5){
					bigTimer = 0;	// fica acesa mais 1.5 seg e depois volta a piscar
					trocou = false;
				}
			}
        }
	}

	 public void TrocaNotes(){
		 semSangue.SetActive(!temSangue);
		 comSangue.SetActive(temSangue);
		 temSangue = !temSangue;
		 Debug.Log("trocou");
	 }
}
