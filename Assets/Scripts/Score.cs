using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	public int discos_totales;
	public GameObject[] discos;

	// Use this for initialization
	void Awake () {

		//incrementamos el numero de discos en la escena
		foreach (GameObject disco in discos) {
			discos_totales += 1;
		}
		//incrementamos el numero de discos en la escena
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
