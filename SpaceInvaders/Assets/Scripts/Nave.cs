using UnityEngine;
using System.Collections;

public class Nave : MonoBehaviour
{
	public float posicaoInicialX = 0.0f;
	public float posicaoInicialY = 1.0f;
	public int speed = 20;
	public Transform limitObject;

	private float limiteEsq;
	private float limiteDir;
	private float limiteCima;
	private float limiteBaixo;

	void Awake()
	{
		Transform nave = GetComponent<Transform> ();

		// Posiçao inicial da nave
		Vector3 tamanhoNave = nave.localScale;
		Vector3 posicaoInicial = new Vector3(
			this.posicaoInicialX,
			tamanhoNave.y / 2 + this.posicaoInicialY,
			tamanhoNave.z / -2
		);
		nave.localPosition = posicaoInicial;

		// Calcula as "fronteiras" do jogo
		this.limiteEsq = this.limitObject.localScale.x / -2 + nave.localScale.x / 2;
		this.limiteDir = -this.limiteEsq;
		this.limiteCima = this.limitObject.localScale.y - nave.localScale.y / 2;
		this.limiteBaixo = nave.localScale.y / 2;
		//Debug.Log (this.limiteCima);
	}

	void Update ()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			Vector3 novaPosicao = transform.position + (Vector3.left * speed * Time.deltaTime);
			transform.position = (novaPosicao.x < this.limiteEsq)
				? new Vector3(this.limiteEsq, novaPosicao.y, novaPosicao.z)
				: novaPosicao;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			Vector3 novaPosicao = transform.position + (Vector3.right * speed * Time.deltaTime);
			transform.position = (novaPosicao.x > this.limiteDir)
				? new Vector3(this.limiteDir, novaPosicao.y, novaPosicao.z)
				: novaPosicao;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			Vector3 novaPosicao = transform.position + (Vector3.up * speed * Time.deltaTime);
			transform.position = (novaPosicao.y > this.limiteCima)
				? new Vector3(novaPosicao.x, this.limiteCima, novaPosicao.z)
				: novaPosicao;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			Vector3 novaPosicao = transform.position + (Vector3.down * speed * Time.deltaTime);
			transform.position = (novaPosicao.y < this.limiteBaixo)
				? new Vector3(novaPosicao.x, this.limiteBaixo, novaPosicao.z)
				: novaPosicao;
		}
	}
}