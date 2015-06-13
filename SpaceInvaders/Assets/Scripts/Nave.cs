using UnityEngine;
using System.Collections;

public class Nave : MonoBehaviour
{
	public float posicaoInicialX = 0.0f;
	public float posicaoInicialY = 1.0f;
	public int speed = 20;
	public Transform limitObject;
    public GameObject explosao;
    public float delayExplosao = 2.5f;

	private Vector3 min;
	private Vector3 max;
	private float limiteCima;
	private float limiteBaixo;

	void Start()
	{
		min = Camera.main.ViewportToWorldPoint(new Vector3(0,0,65));
		max = Camera.main.ViewportToWorldPoint(new Vector3(1,1,65));
	}

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
		this.limiteCima = this.limitObject.localScale.y - nave.localScale.y / 2 - 140;
		this.limiteBaixo = nave.localScale.y / 2;
	}

	void Update ()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			Vector3 novaPosicao = transform.position + (Vector3.left * speed * Time.deltaTime);
			if (novaPosicao.x > min.x)
				transform.position = novaPosicao;
			else
				transform.position = new Vector3(max.x, novaPosicao.y, novaPosicao.z);
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			Vector3 novaPosicao = transform.position + (Vector3.right * speed * Time.deltaTime);
			if (novaPosicao.x < max.x)
				transform.position = novaPosicao;
			else
				transform.position = new Vector3(min.x, novaPosicao.y, novaPosicao.z);
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

    void OnCollisionEnter(Collision col)
    {
        Vector3 position;

        for (int i = 0; i < 5; i++)
        {
            position = transform.position;
            position.x += Random.Range(-7.0f, 7.0f);
            position.y += Random.Range(-7.0f, 7.0f);
            Instantiate(explosao, position, Quaternion.identity);
        }

        Destroy(col.gameObject);
        Destroy(gameObject, delayExplosao);
    }
}