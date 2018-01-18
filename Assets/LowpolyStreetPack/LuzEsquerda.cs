using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzEsquerda : MonoBehaviour
{

    float timer = 0f;
    float bigTimer = 0f;

    // Use this for initialization
    void Start()
    {
        //GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        bigTimer += Time.deltaTime;
        if (bigTimer < 1)
        {
            if (timer > 0.1f)
            {
                GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
                timer = 0;
            }
        }
        else
        {
            GetComponent<Light>().enabled = true;
            if (bigTimer > 2) bigTimer = 0;
        }
    }
}
