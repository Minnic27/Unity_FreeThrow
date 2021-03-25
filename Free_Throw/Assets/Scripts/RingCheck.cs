using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingCheck : MonoBehaviour
{
    public BallShoot ballScript;

    void Start()
    {
        ballScript = GameObject.FindGameObjectWithTag("Spawn").GetComponent<BallShoot>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {
            StartCoroutine(ballScript.Delay());
        }
    }
}
