using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostesController : MonoBehaviour {

    private GameObject[] postes;
    private int childCount;
    private bool isOn;
    
    public GameObject power;

    // Use this for initialization
    void Start () {

        childCount = 0;
        getChildren();

        turnOff();
    }
	
	// Update is called once per frame
	void Update () {
        
        try
        {
            if (power.GetComponent<EnergyController>().IsOn())
            {
                turnOn();
            }
            else
            {
                turnOff();
            }
        }
        catch { }
        
	}

    void getChildren()
    {
        Transform obj = null;
        do
        {
            obj = null;
            try
            {
                obj = transform.GetChild(childCount);
                if (obj != null)
                {
                    childCount++;
                }
            }
            catch (System.Exception e) { }

        } while (obj != null);

        if (childCount > 0)
        {
            postes = new GameObject[childCount];

            for(int i=0; i<childCount; i++)
            {
                postes[i] = this.gameObject.transform.GetChild(i).gameObject;
            }
        }

        //print(childCount);
    }

    public void turnOff()
    {
        for (int i = 0; i < childCount; i++)
        {
            postes[i].transform.GetChild(0).gameObject.SetActive(false);
            postes[i].transform.GetChild(1).gameObject.SetActive(false);
            postes[i].transform.GetChild(2).gameObject.SetActive(false);
        }
        isOn = false;
    }

    public void turnOn()
    {
        for (int i = 0; i < childCount; i++)
        {
            postes[i].transform.GetChild(0).gameObject.SetActive(true);
            postes[i].transform.GetChild(1).gameObject.SetActive(true);
            postes[i].transform.GetChild(2).gameObject.SetActive(true);
        }
        isOn = true;
    }
}
