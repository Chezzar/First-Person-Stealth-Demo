using UnityEngine;
using System.Collections;

public class Player_control : MonoBehaviour {

	/* delegados para acciones de vida
	public delegate void reduccion_vida ();
	public static event reduccion_vida reduce;*/


	//velocidad de movimiento del personaje
	public float velocidad = 3f;
	//velocidad de movimiento del personaje

	//camara del personaje y axis del mouse
	public Camera camara;
	public float axis_x, axis_y;
	//camara del personaje y axis del mouse

	//variable para verificar si ha sido atrapado el jugador
	public bool dead = false;
	//variable para verificar si ha sido atrapado el jugador

	//variabale para obtener el rigidbody del jugador
	Rigidbody char_rb;

	//variables para saber si esta tovcando el suelo( para saltor si es requerido)
	public bool grounded = true;
	public GameObject ground;
	//variables para saber si esta tovcando el suelo( para saltor si es requerido)

	// Use this for initialization
	void Start () {

		//se oculta el cursor al inicializar
		Cursor.visible = false;

		char_rb = GetComponent<Rigidbody> ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		//obtenemos los axis de el mouse
		if (!dead) {
			axis_x = Input.GetAxis ("Mouse X");
			axis_y = Input.GetAxis ("Mouse Y");
		}
		//obtenemos los axis de el mouse


		//metodo para movimiento del persosanaje
		funcionalidad_2 ();
		//metodo para movimiento del persosanaje


		//salto (si es requerido)
		if (Input.GetKeyDown ("space") && grounded && !dead)
			jump ();
		//salto (si es requerido)
	
	}

	//funcion de salto extra(no se utiliza)
	void jump(){

		this.transform.GetComponent<Rigidbody> ().AddForce(new Vector3(0,300,0));
		grounded = false;
	}
	//funcion de salto extra(no se utiliza)

	void funcionalidad_2(){

		//obtenemos los ejes del mouse
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		//obtenemos los ejes del mouse

		//rotamos la camara con respecto a los axis x e y
		this.transform.Rotate (new Vector3(0,axis_x,0));
		camara.transform.Rotate (new Vector3 (-axis_y, 0 ,0)); 
		//rotamos la camara con respecto a los axis x e y


		if (!dead) {

			//calculamos las componentes x , z y multiplicamos por los ejes de direccion
			Vector3 mov_side = transform.right * horizontal * velocidad * Time.deltaTime;
			Vector3 mov_forward = transform.forward  * vertical * velocidad * Time.deltaTime;
			//calculamos las componentes x , z y multiplicamos por los ejes de direccion

			//sumamos las fuerzas a el rigidbody
			char_rb.MovePosition (this.transform.position + mov_side + mov_forward);
			//sumamos las fuerzas a el rigidbody
		}
			

	}


	//parte del codigo si necesitara vida el personaje
	void OnTriggerEnter(Collider node){

		/*if (node.tag == "Enemy") {
			//this.GetComponent<Rigidbody>().AddForce(this.transform.forward * 600);
		}*/
			
	}
	//parte del codigo si necesitara vida el personaje


	//parte del codigo si necesitara saltar el personaje
	void OnTriggerStay(Collider node){

		if (node.tag == "Floor")
			grounded = true;
	}
	//parte del codigo si necesitara saltar el personaje
}
