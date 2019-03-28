using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour {

	//script player
	GameObject char_;
	//script player

	//velocidad de movimiento
	float velocidad = 7f;
	//velocidad de movimiento

	//informacion de rutina de movimiento
	public int estado;
	public GameObject[] nodos;
	public float distancia_atrapado;
	int posicion = 0;
	bool direccion = false;
	public int rutina = 1;
	//informacion de rutina de movimiento

	//rigibody para este personaje
	Rigidbody body_enemy;
	//rigibody para este personaje

	// Use this for initialization
	void Start () {

		//obetenmos el rigidbody de este perosnaje y el gameobject del jugador
		char_ = GameObject.FindGameObjectWithTag ("Player");
		body_enemy = GetComponent<Rigidbody> ();
		//obetenmos el rigidbody de este perosnaje y el gameobject del jugador

	}

	// Update is called once per frame
	void Update () {


		//seleccionamos el tipo de rutina a seguir
		if (rutina == 1)
			rutina_seguir_ruta ();
		
		else if (rutina == 2)
			rutina_seguir_ruta_2 ();

		//seleccionamos el tipo de rutina a seguir


		//funcion para verificar distancia entre el enemigo y el jugador
		atrapar ();
		//funcion para verificar distancia entre el enemigo y el jugador
		
	}

	//funcion para verificar distancia entre el enemigo y el jugador
	void atrapar(){

		//trazamos la distancia entre el jugador y el enemigo y obetemos un valor escalar
		distancia_atrapado = (this.transform.position - char_.transform.position).magnitude;
		//trazamos la distancia entre el jugador y el enemigo y obetemos un valor escalar

		//verificamos si la distancia en menor a 3 y si lo es el personaja a sido atrapado
		if (distancia_atrapado < 3) {
			char_.GetComponent<Player_control>().dead = true;
		}
		//verificamos si la distancia en menor a 3 y si lo es el personaja a sido atrapado
	}
	//funcion para verificar distancia entre el enemigo y el jugador


	//rutina para seguir nodos de ida y regreso
	void rutina_seguir_ruta(){


		//rutina siguiendo los nodos especificados
		if (estado == 0) {

			//verificamos que direcion lleva
			if (!direccion) {

				//verificamos si ha llegado a el numero de nodo especificado si no es asi continuamos moviendonos
				if (transform.position != nodos [posicion].transform.position) {

					//miramos al personaje(ocaciona problemas)
					//transform.LookAt (nodos[posicion].transform.position);
					//miramos al personaje(ocaciona problemas)

					Vector3 mov = Vector3.MoveTowards (this.transform.position, nodos [posicion].transform.position, velocidad / 80);

					body_enemy.MovePosition (mov);
				//verificamos si ha llegado a el numero de nodo especificado si no es asi continuamos moviendonos
				} else {
					//aumentamos el numero de nodo al llegar a la posicion especificada
					if (posicion < nodos.Length)
						posicion += 1;
				}

				//si ha llegado al final de la lista revertimos el sentido
				if (posicion == nodos.Length - 1) {
					direccion = true;
				}

			}
			//esta vez vamos en direccion opuesta de la lista de nodos
			else if (direccion) {
				
				if (transform.position != nodos [posicion].transform.position) {
					//transform.LookAt (nodos[posicion].transform.position);

					Vector3 mov = Vector3.MoveTowards (this.transform.position, nodos [posicion].transform.position, velocidad / 80);
					body_enemy.MovePosition (mov);
				} else {

					if (posicion >= 1)
						posicion -= 1;
				}

				if (posicion == 0) {
					direccion = false;
				}
			}
		}

		//si el personaje ha entrado al rango del enemigo procedemos con el siguiente estado
		else if (estado == 1) {

			//cuando se ha detectado el personaje el enemigo mira a su posicion siempre
			transform.LookAt (char_.transform.position);
			//cuando se ha detectado el personaje el enemigo mira a su posicion siempre

			//calculamos la componente x y multiplicamos por el eje de direccion
			Vector3 mov = transform.forward * Time.deltaTime * velocidad;
			//calculamos la componente x y multiplicamos por el eje de direccion

			//sumamos las fuerzas a el rigidbody
			body_enemy.MovePosition(this.transform.position + mov);
			//sumamos las fuerzas a el rigidbody

		}


	}

	//rutina para seguir nodos de ida y regreso


	//rutina para seguir nodos de ida en una sola direccion

	void rutina_seguir_ruta_2(){

		if (estado == 0) {

			if (!direccion) {
				//if (transform.position.x != nodos [posicion].transform.position.x && transform.position.z != nodos [posicion].transform.position.z) {
				if (transform.position != nodos [posicion].transform.position) {
					//transform.LookAt (nodos[posicion].transform.position);

					Vector3 mov = Vector3.MoveTowards (this.transform.position, nodos [posicion].transform.position, velocidad / 80);
					//Vector3 mov = (transform.forward * Time.deltaTime * velocidad);
					body_enemy.MovePosition (mov);
				} else {

					if (posicion < nodos.Length)
						posicion += 1;
				}

				if (posicion == nodos.Length) {
					posicion = 0;;
				}

			} 
		}
		else if (estado == 1) {

			//cuando se ha detectado el personaje el enemigo mira a su posicion siempre
			transform.LookAt (char_.transform.position);
			//cuando se ha detectado el personaje el enemigo mira a su posicion siempre

			//calculamos la componente x y multiplicamos por el eje de direccion
			Vector3 mov = transform.forward * Time.deltaTime * velocidad;
			//calculamos la componente x y multiplicamos por el eje de direccion

			//sumamos las fuerzas a el rigidbody
			body_enemy.MovePosition(this.transform.position + mov);
			//sumamos las fuerzas a el rigidbody

		}
	}
	//rutina para seguir nodos de ida en una sola direccion

	//verifivcamos si el jugador ha entrado en el rango de vision
	void OnTriggerStay(Collider col){

		if (col.tag == "Player") {
			estado = 1;
		}
	}
	//verifivcamos si el jugador ha entrado en el rango de vision

	//verifivcamos si el jugador ha salido de el rango de vision
	void OnTriggerExit(Collider col){

		if (col.tag == "Player") {
			estado = 0;
		}
	}

	//verifivcamos si el jugador ha salido de el rango de vision
}
