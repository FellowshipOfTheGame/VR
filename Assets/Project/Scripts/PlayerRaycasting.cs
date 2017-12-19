using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycasting : MonoBehaviour {
	public float distanceToSee;
	public GameObject player;
	int ultimo = -1;
	RaycastHit whatIHit;
	Material m_material;
	GameObject refe = null;
	public GameObject[] inventario;
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
			print("entrou");
			if(refe.tag == "Interagir")
				refe.GetComponent<Renderer>().material.SetFloat("_Outline", 0);
		}

		if(hit){
			refe = whatIHit.collider.gameObject;
			if(refe.tag == "Interagir"){
				refe.GetComponent<Renderer>().material.SetFloat("_Outline", 0.1f);
				if (Input.GetKeyDown ("joystick button 2")) {
					ultimo++;
					if (ultimo < inventario.Length) {
						refe.layer = 2;
						refe.transform.SetParent (player.transform, false);
						refe.transform.position = player.transform.position + transform.forward * 2;
						inventario [ultimo] = refe;
						if (ultimo != 0) {
							inventario [ultimo-1].SetActive (false);
						}
					}else {
						print ("Lista CHEIA!");
					}
				}
			}
		}
		else{
			refe = null;
		}
	}
}