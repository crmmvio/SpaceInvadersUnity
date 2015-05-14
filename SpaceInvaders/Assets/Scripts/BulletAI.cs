using UnityEngine;
using System.Collections;

public class BulletAI : MonoBehaviour 
{
	public float speed;

	void Start () 
    {
		rigidbody.velocity = transform.forward * speed;
	}
	
}
