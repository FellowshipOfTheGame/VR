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
			_RotateLeft ();
		} else if (Input.GetMouseButtonDown (1)) {	// Se clicar com botão direito, vira pra direita
			_RotateRight ();
		}
	}

	public void _RotateLeft () {
		_SetRotation (_Rotation + 1);
	}

	public void _RotateRight() {
		_SetRotation (_Rotation - 1);
	}

	public void _SetRotation (int i) {
		_Rotation = i % 8;
		transform.eulerAngles = new Vector3 (0, 0, _Rotation * 45);
	}

	public int _GetRotation () {
		return _Rotation;
	}
}
