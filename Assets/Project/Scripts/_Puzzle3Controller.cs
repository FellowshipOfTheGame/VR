using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class _Puzzle3Controller : MonoBehaviour {

	public static bool _isFinished = false;
    public GameObject PuzzleSound;

	protected static Material[] _numbers = new Material[10];

	protected static int[] _passcode = {7, 2, 1};
	private static bool _passcodeIsCorrect = false;
	[SerializeField]private _Puzzle3Display[] _display = new _Puzzle3Display[3];

	private Animator _animator;

    // Use this for initialization
    void Awake() {
		for (int i = 0; i < _numbers.Length; ++i)
			_numbers [i] = Resources.Load <Material> ("Materials/Number" + i);
		//for (int i = 0; i < _display.Length; ++i)
		//	_display [i] = GameObject.Find ("DigitDisplay" + i).GetComponent<_Puzzle3Display> ();

		_animator = GetComponentInChildren<Animator> ();
    }

    // Update is called once per frame
    void Update() {

    }

	public void CheckIfComplete() {
		for (int i = 0; i < _display.Length; ++i) {
			//Debug.Log(i + "  display: " + _display [i]._currentNumber + "  passcode: " + _passcode [i]);
			if (_display [i]._currentNumber != _passcode [i]) {
				_passcodeIsCorrect = false;
				return;
			}
		}

        //Debug.Log ("FIM!");

		_passcodeIsCorrect = true;
	}

	public void OpenTheDoor() {
		if (_passcodeIsCorrect) {
            PuzzleSound.GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();
			_isFinished = true;
			_animator.SetTrigger ("Open");

			// Deactivate all the Puzzle's Event Triggers :)
			EventTrigger[] _eventTrigger = GetComponentsInChildren<EventTrigger> ();
			for (int i = 0; i < _eventTrigger.Length; ++i)
				_eventTrigger [i].enabled = false;
		}
	}
}