using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRaycast : MonoBehaviour {
    public float distanceGround;
    public GameObject Player;
    RaycastHit whatIStep;
    GameObject refe = null;

    private string lastTouched;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(this.transform.position, Vector3.down, Color.cyan);
        bool hit = Physics.Raycast(this.transform.position, Vector3.down, out whatIStep, distanceGround);

        if (refe != null)
        {
            print(refe.name);
            try
            {
                if (lastTouched != whatIStep.collider.gameObject.name)
                {
                    lastTouched = whatIStep.collider.gameObject.name;
                    print("I touched " + whatIStep.collider.gameObject.name);
                }
            }
            catch (System.Exception) { }
        }

        if (hit)
        {
            refe = whatIStep.collider.gameObject;
        }
        else
        {
            refe = null;
        }
    }
}
