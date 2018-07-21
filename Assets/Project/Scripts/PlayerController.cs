using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    float f;
    float s;
	int flag = 0;
	private bool isScene1 = true;
	private bool isMenu = true;
	public bool isClear = false;

	// Use this for initialization
	void Start () {
        //Cursor.lockState = CursorLockMode.Locked;	

		// checando a cena atual
		if (SceneManager.GetActiveScene().name != "Bosque") isScene1 = false;
		if (SceneManager.GetActiveScene().name != "Menu") isMenu = false;
}
	
	// Update is called once per frame
	void Update () {
		if(!isMenu){
			f = Input.GetAxis("Vertical") * speed * Time.deltaTime;
			s = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
			transform.Translate(s,0,f);
			/*
			if (Input.GetKeyDown("escape")){
				if(flag == 0){
					Cursor.lockState = CursorLockMode.None;
					flag = 1;
				}
				else{
					Cursor.lockState = CursorLockMode.Locked;
					flag = 0;
				}
			} */
		}
		if(isScene1) CheckHeight();
	}

	// checar altura para tratamento da transicao
	public void CheckHeight()
	{
		if (transform.position.y < 25)
		{
			if (transform.position.y < 5)
			{
				// pos: 74.4715, 32.79451, 104.5187 (posicao de respawn)
				// rot: 0, 22.66, 0

				if (isClear)    // vai pra proxima cena pois essa esta concluida
				{
					isScene1 = false;
					SceneManager.LoadScene("Parque", LoadSceneMode.Single);  //Load scene right away
					//SceneManager.LoadScene("Loading", LoadSceneMode.Single);  //Load loading scene
					//loader.GetComponent<SceneLoader>().AuthorizeLoad();

					/** DEFINIR AQUI A IDA PRA PROX CENA QUE AINDA SERA FEITA **/
				}
				else    // respawna pois nao pegou a nota ainda
				{
					transform.position = new Vector3(74.4715f, 32.79451f, 104.5187f);
				}
			}
		}
	}

	public void Cair()
	{
		transform.position = new Vector3(transform.position.x, 25f, transform.position.z);
	}
}
