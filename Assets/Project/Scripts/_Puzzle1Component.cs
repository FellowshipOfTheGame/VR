using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Puzzle1Component : _Rotationable {

	public int _numberOfTicks;	// Número de cliques para dar uma volta completa
    public AudioClip click;
    public AudioClip puzzleSound;
    public AudioClip eletric;
	public GameObject control;

    private static int i = 0;

    // Use this for initialization
    /* 	void Awake () {
            _numberOfTicks = 8;
            _SetTicksPerLoop (_numberOfTicks);
        } */

    // Update is called once per frame
    void Update () {
		if(control.GetComponent<_Puzzle1Controller>().enabled){

            if (Input.GetMouseButtonDown(0))
            {     // Se clicar com botão esquerdo, vira para esquerda
                GetComponent<AudioSource>().PlayOneShot(click);
                _RotateLeft();

                if (i == 0)
                {
                    control.GetComponent<AudioSource>().PlayOneShot(puzzleSound);
                    i++;
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {  // Se clicar com botão direito, vira pra direita
                GetComponent<AudioSource>().PlayOneShot(click);
                _RotateRight();

                if (i == 0)
                {
                    control.GetComponent<AudioSource>().PlayOneShot(puzzleSound);
                    i++;
                }
            }
            
		} else transform.GetComponent<_Puzzle1Component>().enabled = false;
	}

	public void _RotateLeft () {
		_SetRotation (_rotation + 1);
	}

	public void _RotateRight() {
		_SetRotation (_rotation - 1);
	}

	public void Initialize () {
		_numberOfTicks = 8;
		_SetTicksPerLoop (_numberOfTicks);
	}

}
