using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Puzzle3Button : MonoBehaviour {

	public _Puzzle3Display _display;

	private int _changeAmount;
	private _Puzzle3Controller _controller;

	// Use this for initialization
	void Start () {
		_changeAmount = name.Contains ("Up") ? 1 : -1;
		_controller = GetComponentInParent<_Puzzle3Controller> ();
	}

	public void _ButtonClick() {
		_display._ChangeNumberDisplay (_changeAmount);
		_controller.CheckIfComplete ();
	}

}
