﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : MonoBehaviour {
    public bool InsideCar;
    public GameObject CarCamera;
    public GameObject Cercas;
    public GameObject PlayerCamera;
    public GameObject Player;
    //public GameObject EscapeBridgeBorder;
    public float distance;
    private Vector3 InitialPos;
    public Vector3 currentPos;
    
    private GameObject luz1, luz2;
    void Start () {
        InitialPos = transform.position;
        luz1 = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        luz2 = this.gameObject.transform.GetChild(0).GetChild(1).gameObject;
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
        //EscapeBridgeBorder.SetActive(false);
        
        luz1.SetActive(true);
        luz2.SetActive(true);
    }

    private void ExitCar()
    {
        PlayerCamera.SetActive(true);
        CarCamera.SetActive(false);
        Cercas.SetActive(true);
        gameObject.GetComponent<HoverCarControl>().enabled = false;
        //EscapeBridgeBorder.SetActive(true);
        transform.position = InitialPos;

        luz1.SetActive(false);
        luz2.SetActive(false);
    }
        private void DetectPlayer()
    {
        if (Vector3.Distance(PlayerCamera.transform.position, transform.position) <= 10 && Input.GetKey(KeyCode.Z) == true)
        {
            InsideCar = true;
        }
        if(InsideCar==true && Input.GetKey(KeyCode.X) == true)
        {
            Player.transform.position = currentPos;
            InsideCar = false;
        }
    }


}
