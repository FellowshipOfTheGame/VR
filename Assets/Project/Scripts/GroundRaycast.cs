using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRaycast : MonoBehaviour {
    public float distanceGround;
    public GameObject Vio;
    RaycastHit whatIStep;
    string refe = null;
    public AudioClip Violin;
    public bool groot = false;

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
            //print(refe);
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

            if(refe == "Tronco")
            {
                groot = true;
            }
            if (groot && !Vio.GetComponent<AudioSource>().isPlaying)
            {
                Vio.GetComponent<AudioSource>().PlayOneShot(Violin);
                groot = false;
            }
            if(refe == "Grama")
            {
                Vio.GetComponent<AudioSource>().Stop();
            }
        }
        else
        {
            refe = null;
        }
    }
}
