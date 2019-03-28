using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_level : MonoBehaviour {

	public bool llego;

	void OnTriggerStay(Collider col){

		if (col.tag == "Player") {
			llego = true;
		}
	}

	void OnTriggerExit(Collider col){

		if (col.tag == "Player") {
			llego = false;
		}
	}
}
