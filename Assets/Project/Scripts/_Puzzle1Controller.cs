using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Puzzle1Controller : MonoBehaviour {

	public bool _is_finished;
	public _Puzzle1Component[] _mecanismo;

	// Use this for initialization
	void Start () {
		_is_finished = false;
		for (int i = 0; i < _mecanismo.Length; ++i) {
			_mecanismo [i]._set_rotation(Random.Range (1, 7));
//			_mecanismo [i]._set_rotation(1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		_check_if_finished ();
	}

	private void _check_if_finished() {
		int i;
		for (i = 0; i < _mecanismo.Length; ++i) {
			if (_mecanismo [i]._get_rotation() != 0) {
				break;
			}
		}
		if (i >= _mecanismo.Length) {
			_is_finished = true;
		}
	}
		
}
