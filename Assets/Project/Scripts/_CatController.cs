using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class _CatController : MonoBehaviour {

	public float _dist1;
	public float _dist2;
	public GameObject[] _waypoints;
    public GameObject cat;
	public Transform _player;

	private NavMeshAgent _agent;
	private int _wp_max;				// Quantidade maxima de waypoints
	private int _wp_counter = 0;		// Contador de waypoints
	private float _wp_distance;			// Distancia entre o waypoint e o gato
	private float _player_distance;		// Distancia entre o player e o gato
	private bool _running = true;		// Flag para quando o gato estiver andando para um waypoint

	// Use this for initialization
	void Start () {
		_wp_max = _waypoints.Length;
		_agent = GetComponent<NavMeshAgent> ();
		if (_wp_max == 0 || _agent == null) {
			Debug.Log ("ERRO! Não há waypoints para o gato ou o NavMeshAgent não existe");
			DestroyObject (this);
		}
		_MoveToNextWp (_wp_counter, false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!_running) {
            cat.GetComponent<Animator>().Play("Idle", 0);
            _player_distance = Vector3.Distance (_player.position, transform.position);
			//Debug.Log ("_wp_counter % 2: " + (_wp_counter % 2));
			if (_wp_counter == 0) {			// Caso 1, quando o gato está em baixo do poste piscando
				if (_player_distance <= _dist1) {	// Se o player chegar perto, o gato vai para as arvores
					_MoveToNextWp (++_wp_counter, false);
				}
			} else if ((_wp_counter % 2) == 1) {	// Caso 2 (waypoints ímpar), quando o gato espera o player atras da arvore
				if (_player_distance <= _dist2) { 	// Se o player chegar perto, o gato vai para as arvores
					_MoveToNextWp (++_wp_counter, false);
				}
			} else {						// Caso 3 (waypoint par), quando o gato é teletransportado para a proxima arvore
				_MoveToNextWp (++_wp_counter, true);
			}
		} else {
            cat.GetComponent<Animator>().Play("walk", 0);
            _wp_distance = Vector3.Distance (_waypoints [_wp_counter].transform.position, transform.position);
			if (_wp_distance <= 1)
				_running = false;
		}
	}

	private void _MoveToNextWp (int _index, bool _teleport) {
		if (_index >= _wp_max)		// Quando chegar no ultimo wp, o gato é destruido
			Destroy (gameObject);
		else if (_teleport) {		// Se for por teleporte, a posição do gato recebe a posição do waypoint
			_agent.Warp(_waypoints [_index].transform.position);
			_running = false;
		} else {					// Caso contrário, o gato recebe a posição como destino do navmesh
			_agent.destination = _waypoints [_index].transform.position;
			_running = true;
		}
	}
		
}
