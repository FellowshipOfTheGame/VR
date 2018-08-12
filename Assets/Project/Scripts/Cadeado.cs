using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cadeado : MonoBehaviour {

	public GameObject chave;
	public bool abriu;

	private Renderer[] _renderer;
	private bool _destruido;

	// Use this for initialization
	void Start () {
		abriu = false;
		_renderer = GetComponentsInChildren<Renderer> ();
		if (_renderer == null)
			Debug.Log ("Materiais não encontrados!!!!!!!");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetButtonDown("Interact1")){
			if (chave.GetComponent<Chave>().PlayerHas()){
                //Destroy(transform.gameObject);
                GetComponent<AudioSource>().Play();
				Open();
			}
		}
		if (abriu && !_destruido) {
//			Debug.Log ("Leng = " + _renderer.Length);
			for (int i = 0; i < _renderer.Length; ++i) {
				Color _color = _renderer [i].material.color;
				_color.a -= 0.08f;
				Debug.Log ("alpha[" + i + "] = " + _color.a);
				if (_color.a >= 0f)
					_renderer [i].material.color = _color;
				else
					_DestroiCadeado ();
			}
		}
	}

	private void _DestroiCadeado () {
		transform.localScale = new Vector3 (0, 0, 0);
		_destruido = true;
		this.enabled = false;
	}

	private void Open(){
		if (!abriu){
			transform.GetChild(1).gameObject.transform.Rotate(0, -75f, 0, Space.Self);
			abriu = true;
			GetComponent<EventTrigger> ().enabled = false;
			GetComponent<Rigidbody> ().useGravity = false;
		}
	}
}
