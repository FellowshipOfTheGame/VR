using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
	[System.Serializable]
	public struct Inventario { 
		public GameObject[] list;
		public int atual;
		public int ultimo;
		public int cheia;
	};
	public Inventario invent;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (invent.ultimo != -1 && invent.ultimo != 0) {
			if (Input.GetKeyDown ("joystick button 4")) {
				invent.list [invent.atual].SetActive (false);
				invent.atual = (invent.atual - 1) % (invent.ultimo+1);
				if (invent.atual == -1)
					invent.atual = invent.ultimo;
				invent.list [invent.atual].SetActive (true);
			}
			if (Input.GetKeyDown ("joystick button 5")) {
				invent.list [invent.atual].SetActive (false);
				invent.atual = (invent.atual + 1) % (invent.ultimo+1);
				invent.list [invent.atual].SetActive (true);
			}
		}
	}
}
