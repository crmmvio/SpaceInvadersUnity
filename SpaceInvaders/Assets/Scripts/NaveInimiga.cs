using UnityEngine;
using System.Collections;

public class NaveInimiga : MonoBehaviour
{
	public GameObject explosao;
	public float delayExplosao = 2.5f;

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Bullet")
		{
			Instantiate(explosao, transform.position, Quaternion.identity);
			Destroy(col.gameObject);
			Destroy(gameObject, delayExplosao);
		}
	}
}