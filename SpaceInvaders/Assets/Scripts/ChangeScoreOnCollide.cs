using UnityEngine;
using System.Collections;

public class ChangeScoreOnCollide : MonoBehaviour
{

    public int pointValue;


    void OnTriggerEnter()
    {
        GameManager.score += pointValue;
    }
}
