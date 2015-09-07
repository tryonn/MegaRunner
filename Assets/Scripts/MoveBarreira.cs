using UnityEngine;
using System.Collections;

public class MoveBarreira : MonoBehaviour {

	public float speed;
	public Rigidbody2D rgBarreira;

	public Transform barreitaTransform;
	public float limiteX;


	//ta pontuado
	private bool isPontuado;

	// Use this for initialization
	void Start () {
		rgBarreira = GetComponent<Rigidbody2D>();
		barreitaTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		rgBarreira.velocity = new Vector2(-speed, 0);

		if (!isPontuado){
			float posicaoPlayerX = GameObject.Find("Player").transform.position.x;//porcura o player e pega a posicao X
			if (barreitaTransform.position.x < posicaoPlayerX){//posicao X do obstaculo menor que a do Player
				PlayerController.pontos += 1;
				isPontuado = true;
			}
		}

		if (barreitaTransform.position.x <= limiteX){
			Destroy(this.gameObject);
		}
	}
}
