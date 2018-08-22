using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Rotationable : MonoBehaviour {

	protected int _rotation;
	private int _ticksPerLoop;
	private float _degreesPerTick;

	//private Quaternion _rotacao = Quaternion.Euler(0,0,0) * Quaternion.Inverse(Quaternion.Euler(0,0,45));

	// Use this for initialization
	void Start () {
		if (_ticksPerLoop <= 0) {
			Debug.Log ("ERROR! TicksPerLog is 0. It must be a natural number");
			_ticksPerLoop = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void _SetTicksPerLoop (int _ticks) {
		if (_ticks <= 0)
			return;

		_ticksPerLoop = _ticks;
		_degreesPerTick = 360.0f / (float)_ticks;
	}

	public void _SetRotation (int i) {
	//	Debug.Log ("ticksPerLoop: " + _ticksPerLoop + ", degreesPerTick: " + _degreesPerTick);
		_rotation = i % _ticksPerLoop;
	//	_rotacao = transform.rotation;
		transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, _rotation * _degreesPerTick, 0);
		//_Rotate (_rotation < i);
	}

	/*public void _Rotate (bool left) {
		transform.localRotation *= _rotacao;
		_rotation += left ? -1 : 1;
		Debug.Log ("Rotação: " + Quaternion.Euler(0,0,0) * Quaternion.Inverse(Quaternion.Euler(0,0,45)));

		// tentativa de usar quaternion
	}*/

	public int _GetRotation () {
		return _rotation;
	}

}
