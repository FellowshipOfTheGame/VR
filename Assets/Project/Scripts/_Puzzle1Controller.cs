using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class _Puzzle1Controller : MonoBehaviour {

	public _Puzzle1Component[] _mechanism;
	public bool _isFinished;	// Variável para mostrar se o player já completou ou não o puzzle
	public bool _isPuzzleActive;

	// Use this for initialization
	void Awake () {
		_isFinished = false;
		_isPuzzleActive = false;
		for (int i = 0; i < _mechanism.Length; ++i) {
			_mechanism [i]._SetRotation (Random.Range (1, 7));
			_mechanism [i].GetComponent<EventTrigger> ().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			transform.GetComponent<EventTrigger> ().enabled = _isPuzzleActive;
			_ChangePuzzleStatus ();
		}
		_CheckIfFinished ();
	}

	public void _CheckIfFinished() {		// Confere se todos os mecanismos estão com rotação 0 (posição correta)
		for (int i = 0; i < _mechanism.Length; ++i) {
			if (_mechanism [i]._GetRotation() != 0) {
				return;
			}
		}
		_isFinished = true;
		this.enabled = false;		// Desabilita este script e o event trigger quando completa o puzzle
		transform.GetComponent<EventTrigger> ().enabled = false;
		_ChangePuzzleStatus ();
	}

	public void _ChangePuzzleStatus() {					// Ativa e desativa o puzzle
		// canPlayerMove = _isPuzzleActive;				// Controla se o player pode se mover
		_isPuzzleActive = !_isPuzzleActive;
		for (int i = 0; i < _mechanism.Length; ++i) {		// abilita/desabilita o evento de passar o mouse por cima dos mecanismos
			_mechanism [i].GetComponent<EventTrigger> ().enabled = _isPuzzleActive;
		}
		// Aqui precisa de colocar algo com raycast pra habilitar/desabilitar o mecanismo caso o mouse estiver em cima dele quando
		// o player aperta E (buga tanto quando é pra entrar no puzzle quanto para sair) (o if abaixo só resolve o caso de saída).
		// Ainda falta arrumar quando o player aperta E para sair do puzzle sem estar olhando para a 'parede', deixando o script ativo
		// quando deveria estar desativado.
		if (!_isPuzzleActive) {			// desabilita os mecanismo caso o mouse estivesse em cima de algum quando "saísse" do puzzle
			for (int i = 0; i < _mechanism.Length; ++i) {
				_mechanism [i].enabled = false;
			}
		}
	}
}