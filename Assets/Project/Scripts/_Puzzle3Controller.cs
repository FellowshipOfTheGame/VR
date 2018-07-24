using UnityEngine;
using System.Collections;

public class _Puzzle3Controller : MonoBehaviour {

	[SerializeField]public static bool _isFinished = false;

	[SerializeField]protected static Material[] _numbers = new Material[10];

	[SerializeField]protected static int[] _passcode = {7, 2, 1};
	[SerializeField]private _Puzzle3Display[] _display = new _Puzzle3Display[3];

    // Use this for initialization
    void Awake() {
		for (int i = 0; i < _numbers.Length; ++i)
			_numbers [i] = Resources.Load <Material> ("Materials/Number" + i);
		for (int i = 0; i < _display.Length; ++i)
			_display [i] = GameObject.Find ("DigitDisplay" + i).GetComponent<_Puzzle3Display> ();
    }

    // Update is called once per frame
    void Update() {

    }

	public void CheckIfComplete() {
		for (int i = 0; i < _display.Length; ++i) {
			Debug.Log(i + "  display: " + _display [i]._currentNumber + "  passcode: " + _passcode [i]);
			if (_display [i]._currentNumber != _passcode [i]) {
				_isFinished = false;
				return;
			}
		}

		Debug.Log ("FIM!");

		_isFinished = true;
	}

	public void OpenTheDoor(Transform door) {
		door.Rotate (0f, 0f, 90f);
	}
}