using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Von_Spawn : MonoBehaviour {
    public bool SpawnVon;
    private bool flag;
    public GameObject Von;
	// Use this for initialization
	void Start () {
        flag = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (SpawnVon == true)
        {
            
            CreateVon();
            
        }
            
            //SpawnVon == false;
        
        
	}

    private void CreateVon()
    {
        if (Von.active == false)
        {
            Von.SetActive(true);
            Debug.Log("ola");
        }
     
            
        // Von.SetActive() == true;
        
        
    }
}
