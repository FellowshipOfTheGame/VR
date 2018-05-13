using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaDaFonte : MonoBehaviour {
	
	private float count = 0f;
	// Light l;
	GameObject von,fonte,l;
	LanternaBehaviour lb;
	//public GameObject est;
	//public GameObject fonte;

	// Use this for initialization
	void Start () {
		von = transform.Find("EstatuaVon").gameObject;
		fonte = transform.Find("Fonte").gameObject;
		//lb = transform.Find("Lanterna").gameObject.GetComponent<LanternaBehaviour>();
		lb = this.gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<LanternaBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;

		if(count < 3){
			lb.changeState("off");
		} else if(count > 3.1 && count < 4){
			lb.changeState("on");
		} else if(count > 4 && count < 4.1){
			lb.changeState("off");
		} else if(count > 4.2 && count < 4.3){
			lb.changeState("on");
		} else if(count > 4.4 && count < 4.5){
			lb.changeState("off");
		} else if(count > 4.6 && count < 4.7){
			lb.changeState("on");
		} else if(count > 6 && count < 7){
			lb.changeState("off");
			trocaParafonte();
		} else if(count > 9 && count < 10){
			lb.changeState("on");
		}
	}

	void trocaParafonte(){
		//Debug.Log("trocando..");
		von.SetActive(false);
		fonte.SetActive(true);
	}

}