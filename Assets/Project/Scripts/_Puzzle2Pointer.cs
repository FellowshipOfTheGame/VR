using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Puzzle2Pointer : _Rotationable {

	public int _numberOfTicks;	// Número de cliques para dar uma volta completa

	// Use this for initialization
	void Start () {
		_numberOfTicks = (name == "Minute") ? 60 : 12*60;	// Confere se é o ponteiro de minutos ou o de hora
		_SetTicksPerLoop (_numberOfTicks);
	}

	public void _AdvanceClock(int amount) {
		_SetRotation (_rotation - amount);
	}
}
