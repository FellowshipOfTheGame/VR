using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycasting : MonoBehaviour {
	public float distanceToSee;
	RaycastHit whatIHit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
				Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

				if(Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee)){
					Debug.Log("I touched " + whatIHit.collider.gameObject.name);
					//renderer.material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
					if(whatIHit.collider.gameObject.name == "Sphere" || whatIHit.collider.gameObject.name == "Cube"){
						Debug.Log("HII");
					}
				}
	}
}
