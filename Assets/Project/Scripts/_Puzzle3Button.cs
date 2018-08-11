using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class _Puzzle3Button : MonoBehaviour {

	public _Puzzle3Display _display;

	private int _changeAmount;
	private _Puzzle3Controller _controller;
	private EventTrigger _eventTrigger;

	// Use this for initialization
	void Start () {
		_changeAmount = name.Contains ("Up") ? 1 : -1;
		_controller = GetComponentInParent<_Puzzle3Controller> ();
		_display = GetComponentInParent<_Puzzle3Display> ();

		_eventTrigger = _EventsTrigger.AddComponent (gameObject);
		_EventsTrigger.AddNewEvent (_eventTrigger, EventTriggerType.PointerClick, (BaseEventData) => {
			this._ButtonClick ();
		});
	}

	public void _ButtonClick() {
		_display._ChangeNumberDisplay (_changeAmount);
		_controller.CheckIfComplete ();
	}

}
