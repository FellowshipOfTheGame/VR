using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaDaFonte : MonoBehaviour {
	
	private float count = 0f;

	//public GameObject est;
	//public GameObject fonte;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;

		if(count < 3){
			transform.GetChild(0).GetChild(0).gameObject.transform.GetComponent<Light>().enabled = false;
		} else if(count > 3.1 && count < 4){
			transform.GetChild(0).GetChild(0).gameObject.transform.GetComponent<Light>().enabled = true;
		} else if(count > 4 && count < 4.1){
			transform.GetChild(0).GetChild(0).gameObject.transform.GetComponent<Light>().enabled = false;
		} else if(count > 4.2 && count < 4.3){
			transform.GetChild(0).GetChild(0).gameObject.transform.GetComponent<Light>().enabled = true;
		} else if(count > 4.4 && count < 4.5){
			transform.GetChild(0).GetChild(0).gameObject.transform.GetComponent<Light>().enabled = false;
		} else if(count > 4.6 && count < 4.7){
			transform.GetChild(0).GetChild(0).gameObject.transform.GetComponent<Light>().enabled = true;
		} else if(count > 6 && count < 7){
			transform.GetChild(0).GetChild(0).gameObject.transform.GetComponent<Light>().enabled = false;
			trocaParafonte();
			transform.GetChild(1).GetChild(0).gameObject.transform.GetComponent<Light>().enabled = false;
		} else if(count > 9 && count < 10){
			transform.GetChild(1).GetChild(0).gameObject.transform.GetComponent<Light>().enabled = true;
		}
	}

	void trocaParafonte(){
		//Debug.Log("trocando..");
		transform.GetChild(0).gameObject.SetActive(false);
		transform.GetChild(1).gameObject.SetActive(true);
	}

}