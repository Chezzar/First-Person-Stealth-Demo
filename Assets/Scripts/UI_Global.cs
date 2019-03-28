using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UI_Global : MonoBehaviour {

	Player_control char_;
	GameObject score_text;
	Text score;
	Score score_;
	int discos_totales_;
	End_level end_level;

	public GameObject Retry_button;
	public GameObject Quit_button;

	// Use this for initialization
	void Awake () {

		char_ = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player_control>();

		//obetenemos los objetos que contiene el score de la interfaz grafica
		score_text = GameObject.Find ("UI_Score");
		score = score_text.GetComponent<Text> ();

		Retry_button = GameObject.FindGameObjectWithTag("Canvas").transform.Find("Retry").gameObject;
		Quit_button =  GameObject.FindGameObjectWithTag("Canvas").transform.Find ("End").gameObject;
		//obetenemos los objetos que contiene el score de la interfaz grafica

		//obtenemos el score de el scrip Score y End_level
		score_ = GameObject.FindGameObjectWithTag ("Score").GetComponent<Score>();
		end_level = GameObject.FindGameObjectWithTag ("End_level").GetComponent<End_level> ();
		//obtenemos el score de el scrip Score y End_level

	}

	void Start(){

		//actualizamos el valor de los discos totales
		discos_totales_ = score_.discos_totales;
		//actualizamos el valor de los discos totales

		//colocamos el valor del text con respecto al valor del script Score
		score.text = "DISCOS RESTANTES" + "   " + discos_totales_.ToString ();
		//colocamos el valor del text con respecto al valor del script Score
	}
	
	// Update is called once per frame
	void Update () {

		if (discos_totales_ > 0) {
			//actualizamos el valor de los discos totales
			discos_totales_ = score_.discos_totales;
			//actualizamos el valor de los discos totales

			//colocamos el valor del text con respecto al valor del script Score
			score.text = "DISCOS RESTANTES" + "   " + discos_totales_.ToString ();
			//colocamos el valor del text con respecto al valor del script Score
		} else if (discos_totales_ < 1 && end_level.llego) {

			//juego ganado
			score.text = "HAS GANADO!!!";
			//juego ganado

			//activamos los botones de la interfaz y el cursor
			Retry_button.SetActive (true);
			Quit_button.SetActive (true);
			Cursor.visible = true;
			//activamos los botones de la interfaz y el cursor
		} 

		//si ha sido atrapado el personaje desactivamos el control y activamos los botones de terminar y reiniciar
		if (char_.dead) {

			//juego perdido
			score.text = "HAS SIDO ATRAPADO";
			//juego perdido

			//activamos los botones de la interfaz y el cursor
			Retry_button.SetActive (true);
			Quit_button.SetActive (true);
			Cursor.visible = true;
			//activamos los botones de la interfaz y el cursor
		}
		//si ha sido atrapado el personaje desactivamos el control y activamos los botones de terminar y reiniciar

		//terminar el juego en cualquier momento
		if (Input.GetKey (KeyCode.Escape))
			Quit ();
		//terminar el juego en cualquier momento
	}

	public void Retry(){

		SceneManager.LoadScene ("LevelScene");
	}

	public void Quit(){

		Application.Quit ();
	}
}
