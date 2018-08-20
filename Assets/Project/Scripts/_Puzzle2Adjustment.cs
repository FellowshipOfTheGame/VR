using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class _Puzzle2Adjustment : MonoBehaviour {

	public int _minutesAdjust;
    public AudioClip click;
    public AudioClip PuzzleSound;
    public GameObject ClockTower;

	private _Puzzle2Pointer _minute;
	private _Puzzle2Pointer _hour;
	private _Puzzle2Controller _controller;
    private static int i = 0;

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
		if (_controller.hasEnergy() && (!_controller.isFinished())){
            if (Input.GetMouseButtonDown(0))
            {
                _AdjustClock(_minutesAdjust);
                GetComponent<AudioSource>().PlayOneShot(click);
                if(i == 0)
                {
                    ClockTower.GetComponent<AudioSource>().PlayOneShot(PuzzleSound);
                    i++;
                }
            }
		}
	}
		
	public void _AdjustClock(int _adjustment) {
		_minute._AdvanceClock (_adjustment);
		_hour._AdvanceClock (_adjustment);

		_controller._CheckIfComplete ();
	}
}
