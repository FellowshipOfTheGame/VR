using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Puzzle1Component : _Rotationable {

	public int _numberOfTicks;	// Número de cliques para dar uma volta completa

	// Use this for initialization
	void Awake () {
		_numberOfTicks = 8;
		_SetTicksPerLoop (_numberOfTicks);
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
		_SetRotation (_rotation + 1);
	}

	public void _RotateRight() {
		_SetRotation (_rotation - 1);
	}

}
