using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : MonoBehaviour {
    public bool InsideCar;
    public GameObject CarCamera;
    public GameObject Cercas;
    public GameObject PlayerCamera;
    public GameObject Player;
    public GameObject EscapeBridgeBorder;
    public float distance;
    private Vector3 InitialPos;
    public Vector3 currentPos;
    void Start () {
        InitialPos = transform.position;
	}

    void Update()
    {
        distance = Vector3.Distance(PlayerCamera.transform.position, transform.position);
        currentPos = transform.position;
        DetectPlayer();
        if (InsideCar == true)
        {
            EnterCar();

        }
        if (InsideCar == false)
        {
            ExitCar();
        }
    }


    private void EnterCar()
    {
        CarCamera.SetActive(true);
        PlayerCamera.SetActive(false);
        Cercas.SetActive(false);
        gameObject.GetComponent<HoverCarControl>().enabled = true;
        EscapeBridgeBorder.SetActive(false);
        

    }

    private void ExitCar()
    {
        PlayerCamera.SetActive(true);
        CarCamera.SetActive(false);
        Cercas.SetActive(true);
        gameObject.GetComponent<HoverCarControl>().enabled = false;
        EscapeBridgeBorder.SetActive(true);
        transform.position = InitialPos;

    }
        private void DetectPlayer()
    {
        if (Vector3.Distance(PlayerCamera.transform.position, transform.position) <= 10 && (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Interact1")))
        {
            InsideCar = true;
        }
        if(InsideCar==true && (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("Interact1")))
        {
            Player.transform.position = currentPos;
            InsideCar = false;
        }
    }


}
