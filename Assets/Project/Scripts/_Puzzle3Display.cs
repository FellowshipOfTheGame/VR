using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Puzzle3Display : _Puzzle3Controller {

	public int _currentNumber;
	private Renderer _renderer;

	// Use this for initialization
	void Start () {
		_currentNumber = 6;
		_renderer = gameObject.GetComponent<Renderer> ();
		Debug.Log("_number.length: " + _numbers.Length);
		_renderer.material = _numbers [_currentNumber];
	}
	
	public void _ChangeNumberDisplay(int amount) {
		_currentNumber = Mod(_currentNumber + amount, _numbers.Length);
		_renderer.material = _numbers [_currentNumber];
	}

	private int Mod(int a, int b) {
		return (a % b + b) % b;
	}
}
