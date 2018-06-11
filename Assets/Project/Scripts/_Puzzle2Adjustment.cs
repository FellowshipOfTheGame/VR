using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Puzzle2Adjustment : MonoBehaviour {

	public int _minutesAdjust;

	private _Puzzle2Pointer _minute;
	private _Puzzle2Pointer _hour;

	void Start () {
		_minute = GameObject.Find ("Minute").GetComponent<_Puzzle2Pointer> ();
		_hour = GameObject.Find ("Hour").GetComponent<_Puzzle2Pointer> ();
		if (_minute == null || _hour == null)
			Debug.Log ("ERRO! Não foi possível encontrar os ponteiros do relógio.");
	}

	void Update () {
		if (Input.GetMouseButtonDown (0))
			_AdjustClock ();
	}

	public void _AdjustClock() {
		_minute._AdvanceClock (_minutesAdjust);
		_hour._AdvanceClock (_minutesAdjust);
	}
}
