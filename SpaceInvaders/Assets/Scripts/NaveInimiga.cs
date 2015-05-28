using UnityEngine;
using System.Collections;

public class NaveInimiga : MonoBehaviour
{
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Bullet")
		{
			Destroy(col.gameObject);
			Destroy(gameObject);
		}
	}
}