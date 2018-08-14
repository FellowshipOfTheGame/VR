using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityStandardAssets.Characters.FirstPerson;

public class _Puzzle1Controller : MonoBehaviour {

	public _Puzzle1Component[] _mechanism;
	public bool _isFinished;	// Variável para mostrar se o player já completou ou não o puzzle
//	public bool _isPuzzleActive;
	public float _maxDistance;
//	public PostesController _luzPostes;
	public EnergyController _energy;
    public AudioClip spark;
    public AudioClip holofote;
    public GameObject Wall; 

//	private FirstPersonController _player;
	private Transform _camera;
	private RaycastHit _hit;
    private double _walltime;

	// Use this for initialization
	void Awake () {
		_isFinished = false;
//		_isPuzzleActive = false;
		_mechanism = GetComponentsInChildren<_Puzzle1Component> ();
		_camera = GameObject.FindGameObjectWithTag ("MainCamera").transform;
//		_player = GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ();

		for (int i = 0; i < _mechanism.Length; ++i) {
			
			_mechanism [i].Initialize();

			int Number = Random.Range (1, (i == 0 || i == _mechanism.Length-1) ? 3 : 7);
			//Debug.Log(Number);
			_mechanism [i]._SetRotation (Number);
//			_mechanism [i].GetComponent<EventTrigger> ().enabled = false;
		}
        GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
/*		if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(_camera.position, transform.position) < _maxDistance) {
			GetComponent<EventTrigger> ().enabled = _isPuzzleActive;
			_ChangePuzzleStatus ();
		}
*/		_CheckIfFinished ();
        _walltime += Time.deltaTime;
      // print(_walltime);
        if (_walltime >= 7.0f && _isFinished == false)
        {
            _walltime = 0;
            //Wall.GetComponent<AudioSource>().Play();
        }
	}

	public void _CheckIfFinished() {		// Confere se todos os mecanismos estão com rotação 0 (posição correta)
		for (int i = 0; i < _mechanism.Length; ++i) {
            //Debug.Log("rotação["+i+"]: " + (_mechanism[i]._GetRotation() % ((i == 0 || i == _mechanism.Length - 1) ? 180 : 360)));
            //Debug.Log("rotaçao%180=" + (_mechanism[i]._GetRotation() % 180));
            if ((_mechanism [i]._GetRotation() % ((i == 0 || i == _mechanism.Length - 1) ? 4 : 8)) != 0) {
				return;
			}
		}

        GetComponent<AudioSource>().Stop();
		// Se ainda não saiu da função, então é porque o puzzle já está finalizado
		Debug.Log("TERMINOU");
		if (_energy != null)
			_energy.turnOn ();
        GetComponent<AudioSource>().PlayOneShot(holofote);
		_isFinished = true;
		transform.GetComponent<EventTrigger> ().enabled = false;
		_DeactivatePuzzle ();
		this.enabled = false;		// Desabilita este script e o event trigger quando completa o puzzle
	}

	public void _DeactivatePuzzle() {					// Ativa e desativa o puzzle
//		_player.m_MovementEnabled = _isPuzzleActive;				// Controla se o player pode se mover
//		_isPuzzleActive = !_isPuzzleActive;
		for (int i = 0; i < _mechanism.Length; ++i) {		// abilita/desabilita o evento de passar o mouse por cima dos mecanismos
			_mechanism [i].GetComponent<EventTrigger> ().enabled = false;
		}

		int layerMask = 1 << 12;	// Layer do Puzzle1
		Physics.Raycast (_camera.position, _camera.forward, out _hit, 10, layerMask);

		if (_hit.transform == null)		// Caso não colida com nada, o player estava olhando para fora do puzzle
			this.enabled = false;	// então desativa o puzzle manualmente...
		else{
			Debug.Log(_hit.transform.name);
			if (_hit.transform.GetComponent<_Puzzle1Component> () != null) // Caso esteja olhando para um mecanismo
				_hit.transform.GetComponent<_Puzzle1Component> ().enabled = false;	// ativa/desativa ele manualmente
		}
	}

}
