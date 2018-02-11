using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycasting : MonoBehaviour {
	public float distanceToSee;
	public GameObject player;
	RaycastHit whatIHit;
	Material m_material;
	GameObject refe = null;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

		bool hit = Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee);

		//Debug.Log("I touched " + whatIHit.collider.gameObject.name);
		//renderer.material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
		if(refe != null){
			print(refe.name);
			if(refe.tag == "Interagir")
				refe.GetComponent<Renderer>().material.SetFloat("_Outline", 0);
			if(refe.tag == "Note")
				refe.GetComponent<Renderer>().material.SetFloat("_Outline", 0);
		}

		if(hit){
			refe = whatIHit.collider.gameObject;
			print (refe.name);
			if (refe.tag == "Interagir") {
				refe.GetComponent<Renderer> ().material.SetFloat ("_Outline", 0.005f);
				if (Input.GetKeyDown ("joystick button 2") && player.GetComponent<PlayerInventory> ().invent.cheia != 1) {
					player.GetComponent<PlayerInventory> ().invent.ultimo++;
					if (player.GetComponent<PlayerInventory> ().invent.atual == -1) {
						player.GetComponent<PlayerInventory> ().invent.atual++;
					}
					if (player.GetComponent<PlayerInventory> ().invent.ultimo < player.GetComponent<PlayerInventory> ().invent.list.Length) {
						refe.layer = 2;
						refe.transform.SetParent (player.transform, false);
						refe.transform.position = player.transform.position + transform.forward * 2;
						player.GetComponent<PlayerInventory> ().invent.list [player.GetComponent<PlayerInventory> ().invent.ultimo] = refe;
						player.GetComponent<PlayerInventory> ().invent.list [player.GetComponent<PlayerInventory> ().invent.atual].SetActive (false);
						player.GetComponent<PlayerInventory> ().invent.atual = player.GetComponent<PlayerInventory> ().invent.ultimo;
						player.GetComponent<PlayerInventory> ().invent.list [player.GetComponent<PlayerInventory> ().invent.atual].SetActive (true);
					} else {
						player.GetComponent<PlayerInventory> ().invent.cheia = 1;
						player.GetComponent<PlayerInventory> ().invent.ultimo -= 1;
					}
				} else {
					print ("Lista CHEIA!");
				}
			} else if (refe.tag == "Note") {
				refe.GetComponent<Renderer> ().material.SetFloat ("_Outline", 0.005f);
				if ((Input.GetKeyDown ("joystick button 2") || Input.GetKeyDown (KeyCode.Mouse0)) && refe.GetComponent<Note> ().noteImage.enabled != true) {
					refe.GetComponent<Note> ().ShowNoteImage ();
				}
			} else if (refe.tag == "Lixeira") {
				refe.GetComponent<Renderer> ().material.SetFloat ("_Outline", 0.005f);
				if ((Input.GetKeyDown ("joystick button 2") || Input.GetKeyDown (KeyCode.Mouse0))){
					refe.GetComponent<LixeiraHide> ().HideLixeira();
				}
			}
		}
		else{
			refe = null;
		}
	}
}