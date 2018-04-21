using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotoesLigacao : MonoBehaviour {
    

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Press()
    {
        // Debug.Log("Parent: " + transform.parent.parent.name);

        transform.parent.parent.GetComponent<LigacaoController>().Press(name);
    }
}
