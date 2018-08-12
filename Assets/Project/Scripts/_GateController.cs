using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class _GateController : MonoBehaviour {

	public Cadeado[] _lock;
	public CutscenePlayer _cutscene;

	private EventTrigger _eventTrigger;

	// Use this for initialization
	void Start () {
		if (_lock == null) {
			Debug.Log ("ERRO! Cadeados não encontrados!!!!!!!!!!");
			Destroy (this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		_CheckIfFinished ();
	}

	private void _CheckIfFinished() {
		Debug.Log ("Checando se foi finalizado");
		for (int i = 0; i < _lock.Length; ++i) {
			Debug.Log ("cadeado " + i);
			if (_lock [i].abriu != true)	// Caso o cadeado não esteja aberto, sai da função.
				return;
		}

		_eventTrigger = _EventsTrigger.AddComponent (gameObject);
		_EventsTrigger.AddNewEvent (_eventTrigger, EventTriggerType.PointerClick, (BaseEventData) => {
			this._OpenGate ();
		});
	}

	public void _OpenGate() {
		Debug.Log ("FIM!!");
		_cutscene.currscene = 4;
		_cutscene.startplaying = true;
	}

}