using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRaycast : MonoBehaviour {
    public float distanceGround;
    public GameObject Player;
    RaycastHit whatIStep;
    string refe = null;
    public AudioClip Violin;
    bool groot = false;

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
            print(refe);
            try
            {
                if (lastTouched != whatIStep.collider.gameObject.tag)
                {
                    
                    print("I touched " + whatIStep.collider.gameObject.tag);
                }
            }
            catch (System.Exception) { }
        }

        if (hit)
        {
            refe = whatIStep.collider.gameObject.tag;

            if(refe == "Tronco" && !groot)
            {
                GetComponent<AudioSource>().PlayOneShot(Violin);
                groot = true;
            }
            if(refe == "Grama")
            {
                groot = false;
            }
        }
        else
        {
            refe = null;
        }
    }
}
