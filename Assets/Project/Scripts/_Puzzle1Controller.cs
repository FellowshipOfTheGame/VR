using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class _Puzzle1Controller : MonoBehaviour {

	public _Puzzle1Component[] _mecanismo;
	public bool _finished;
	public bool _enabled;

	// Use this for initialization
	void Awake () {
		_finished = false;
		_enabled = false;
		for (int i = 0; i < _mecanismo.Length; ++i) {
			_mecanismo [i]._set_rotation(Random.Range (1, 7));
			_mecanismo [i].GetComponent<EventTrigger> ().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			_enabled = !_enabled;
			_activate_puzzle();
//			gameObject.GetComponent<EventTrigger> ().enabled = _enabled;
		}
		_check_if_finished ();
	}

	public void _check_if_finished() {		// Confere se todos os mecanismos estão com rotação 0 (posição correta)
		for (int i = 0; i < _mecanismo.Length; ++i) {
			if (_mecanismo [i]._get_rotation() != 0) {
				return;
			}
		}
		_finished = true;
	}

	public void _activate_puzzle() {
		for (int i = 0; i < _mecanismo.Length; ++i) {
			_mecanismo [i].GetComponent<EventTrigger> ().enabled = _enabled;
		}
	}
}