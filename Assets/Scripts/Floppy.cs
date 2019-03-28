using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floppy : MonoBehaviour {

	//script que contiene el score
	Score score_;
	//script que contiene el score

	//solo una vez debe de reducirse el score
	bool una_vez = false;
	//solo una vez debe de reducirse el score

	// Use this for initialization
	void Start () {

		//obetenemos el script que contiene el score
		score_ = GameObject.FindGameObjectWithTag ("Score").GetComponent<Score>();
		//obetenemos el script que contiene el score

	}
	
	void OnTriggerEnter(Collider col){

		//si el jugador toca el dico reducimos la cantidad
		if(col.tag == "Player"){

			if (!una_vez) {
				score_.discos_totales -= 1;
				una_vez = true;
			}
				
			Destroy (this.gameObject);
		}
		//si el jugador toca el dico reducimos la cantidad
	}
}
