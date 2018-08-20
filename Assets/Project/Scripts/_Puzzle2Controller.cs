using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Puzzle2Controller : MonoBehaviour {

	public bool _isFinished;
	public Vector2 _finishTime;
	public GameObject _key;
	public GameObject _power;
    public GameObject ClockTower;

	private GameObject _spawnPoint;
	private Vector2 _currentTime;
	private _Puzzle2Pointer _minute;
	private _Puzzle2Pointer _hour;
//	private _Puzzle2Adjustment[] _adjusters;

	// Use this for initialization
	void Start () {
//		_adjusters = GetComponentsInChildren <_Puzzle2Adjustment> ();
		_minute = GameObject.Find ("Minute").GetComponent <_Puzzle2Pointer> ();
		_hour = GameObject.Find ("Hour").GetComponent <_Puzzle2Pointer> ();
		_spawnPoint = GameObject.Find ("SpawnPoint");

		_currentTime = new Vector2 (6, 30);		// seta o horário do relógio para 6:33.

		_minute._AdvanceClock ((int)_currentTime.y);
		_hour._AdvanceClock ((int)(_currentTime.x * 60 + _currentTime.y));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool hasEnergy(){
		return _power.GetComponent<EnergyController>().IsOn();
	}

	public void _CheckIfComplete() {
		_currentTime.y = -1 * (int) _minute._GetRotation ();
		_currentTime.x = -1 * (int) _hour._GetRotation () / (int) 60;

		if (_currentTime == _finishTime)
			StartCoroutine(_FinishPuzzle ());
	}

	public IEnumerator _FinishPuzzle() {
        GetComponent<AudioSource>().Play();
        ClockTower.GetComponent<AudioSource>().Stop();
        _isFinished = true;

        yield return new WaitForSecondsRealtime(12);
		Vector3 pos = _spawnPoint.transform.position;
		_key.transform.position = pos;
		//Instantiate (_key, _spawnPoint.transform.position, Quaternion.identity);

	}

	public bool isFinished(){
		return _isFinished;
	}
}