using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rgPlayer;
	private Animator anim;
	private Transform groundCheck;
	public LayerMask whatIsGround;

	public float forceJump;
	public bool isGround;
	public bool isSlide;

	public float timeSlide;
	private float tempoTime; 

	public GameObject collisorEmPE;
	public GameObject colisorDeitado;

	private AudioSource som;
	//som
	public AudioClip jumpFX;
	public AudioClip slideFX;


	//pontos
	public Text pontuacao;
	public static int pontos;//para ser acessado no script da barreira

	// Use this for initialization
	void Start () {
		rgPlayer = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		som = GetComponent<AudioSource>();
		//procura o objeto na cena
		groundCheck = GameObject.Find("groundCheck").transform;
		collisorEmPE.SetActive(true);
		colisorDeitado.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {

		pontuacao.text = pontos.ToString();

		isGround = Physics2D.OverlapCircle(groundCheck.position, 0.02f, whatIsGround);

		//controle do pulo
		if (Input.GetMouseButtonDown(0) && isGround){
			rgPlayer.AddForce(new Vector2(0, forceJump));
			isSlide = false;
			collisorEmPE.SetActive(true);
			colisorDeitado.SetActive(false);
			som.PlayOneShot(jumpFX);
		}

		//controle do slide
		if (Input.GetMouseButtonDown(1) && isGround && !isSlide){
			isSlide = true;
			tempoTime = 0;
			collisorEmPE.SetActive(false);
			colisorDeitado.SetActive(true);
			som.PlayOneShot(slideFX);
		}

		if (isSlide){
			tempoTime += Time.deltaTime;
			if (tempoTime >= timeSlide){
				collisorEmPE.SetActive(true);
				colisorDeitado.SetActive(false);
				isSlide = false;
			}
		}

		anim.SetBool("grounded", isGround);
		anim.SetBool("slide", isSlide);
	}

	void OnTriggerEnter2D(){
		Application.LoadLevel("GameOver");
	}
}
