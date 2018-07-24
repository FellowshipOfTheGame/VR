using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class _Puzzle2Adjustment : MonoBehaviour {

	public int _minutesAdjust;

	private _Puzzle2Pointer _minute;
	private _Puzzle2Pointer _hour;
	private _Puzzle2Controller _controller;

	private EventTrigger _eventTrigger;

	void Awake () {
		_eventTrigger = _EventsTrigger.AddComponent (gameObject);
		_EventsTrigger.AddEnterAndExit (_eventTrigger, this);
	}

	void Start () {
		_minute = GameObject.Find ("Minute").GetComponent<_Puzzle2Pointer> ();
		_hour = GameObject.Find ("Hour").GetComponent<_Puzzle2Pointer> ();
		if (_minute == null || _hour == null)
			Debug.Log ("ERRO! Não foi possível encontrar os ponteiros do relógio.");

		_controller = transform.GetComponentInParent<_Puzzle2Controller> ();

	}

	void Update () {
		if (Input.GetMouseButtonDown (0))
			_AdjustClock (_minutesAdjust);
	}
		
	public void _AdjustClock(int _adjustment) {
		_minute._AdvanceClock (_adjustment);
		_hour._AdvanceClock (_adjustment);

		_controller._CheckIfComplete ();
	}
}
