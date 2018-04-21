using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigacaoController : MonoBehaviour {

    private int left = 0;
    private bool leftPressed = false;

    private int right = 0;
    private bool rightPressed = false;

    private int[] comb;

    // Use this for initialization
    void Start()
    {
        ArrayList botoesAtivos = new ArrayList();

        comb = new int[5];

        // gabarito
        comb[1] = 3;
        comb[2] = 1;
        comb[3] = 4;
        comb[4] = 2;
        // fim gabarito
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Press(string nome)
    {
        string op = nome;

        //print("Pressionou "+op);

        switch (op)
        {
            case "A":
                left = 1;
                leftPressed = true;
                break;
            case "B":
                left = 2;
                leftPressed = true;
                break;
            case "C":
                left = 3;
                leftPressed = true;
                break;
            case "D":
                left = 4;
                leftPressed = true;
                break;

            case "1":
                right = 1;
                rightPressed = true;
                break;
            case "2":
                right = 2;
                rightPressed = true;
                break;
            case "3":
                right = 3;
                rightPressed = true;
                break;
            case "4":
                right = 4;
                rightPressed = true;
                break;
            default:
                break;
        }

        //print("Esq: " + leftPressed + " / Dir: " + rightPressed);

        if (leftPressed && rightPressed)
        {
            print("Checkou");
            CheckCombination();
        }
    }

    public void CheckCombination()
    {
        if (comb[left] == right)
        {
            print("Acertou! " + left + " com " + right);
            AcceptCombination();
        }


        left = 0;
        right = 0;
        leftPressed = false;
        rightPressed = false;
    }

    public void AcceptCombination()
    {

    }
}
