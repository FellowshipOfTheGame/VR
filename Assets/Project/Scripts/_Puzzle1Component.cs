using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Puzzle1Component : MonoBehaviour {

	private int _Rotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {		// Se clicar com botão esquerdo, vira para esquerda
			_rotate_left ();
		} else if (Input.GetMouseButtonDown (1)) {	// Se clicar com botão direito, vira pra direita
			_rotate_right ();
		}
	}

	public void _rotate_left () {
		_set_rotation (_Rotation + 1);
	}

	public void _rotate_right() {
		_set_rotation (_Rotation - 1);
	}

	public void _set_rotation (int i) {
		_Rotation = i % 8;
		transform.eulerAngles = new Vector3 (0, 0, _Rotation * 45);
	}

	public int _get_rotation () {
		return _Rotation;
	}
}
