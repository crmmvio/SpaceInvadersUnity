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
            for (int i = 0; i < 5; i++)
            {
                Vector3 position = transform.position;
                position.x += Random.Range(-7.0f, 7.0f);
                position.y += Random.Range(-7.0f, 7.0f);
                Instantiate(explosao, position, Quaternion.identity);

            }
            Destroy(col.gameObject);
			Destroy(gameObject, delayExplosao);
		}
	}
}