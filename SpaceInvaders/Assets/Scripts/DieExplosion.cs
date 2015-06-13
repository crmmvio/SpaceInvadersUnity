using UnityEngine;
using System.Collections;

public class DieExplosion : MonoBehaviour 
{
    void Start()
    {
        Destroy(gameObject, 2.0f);
    }
}
