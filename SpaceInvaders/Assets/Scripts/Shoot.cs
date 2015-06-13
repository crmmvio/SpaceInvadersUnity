using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	public GameObject bullet;
    public Transform[] weapons;
    public float timeToShot = 0.2f;
    private float lastShot;

	void Update () 
    {
        if (Input.GetKey(KeyCode.Space) && (Time.time - lastShot) > timeToShot)
        {
            foreach (Transform weapon in weapons)
                Instantiate(bullet, weapon.position, weapon.rotation);

            lastShot = Time.time;
        }
            
	}
}
