using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Von_Behavior : MonoBehaviour {
    public GameObject target;
    public UnityEngine.AI.NavMeshAgent agent;
    private AudioSource audio;
    public AudioClip CatchSound;
    // Use this for initialization
    void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = target.transform.position;
        audio = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        agent.destination = target.transform.position;
        CatchPlayer();
    }
    private void BucketVon()
    {

    }
    private void CatchPlayer()
    {
        if(Vector3.Magnitude(transform.position - target.transform.position) < 5)
        { 
            gameObject.SetActive(false);
        }

    }
}
