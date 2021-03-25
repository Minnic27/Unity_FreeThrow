using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingCheck : MonoBehaviour
{
    public BallShoot ballScript;

    void Start()
    {
        ballScript = GameObject.FindGameObjectWithTag("Spawn").GetComponent<BallShoot>(); // access BallShoot script
    }

    void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.tag == "Ball") && (ballScript.madeShot == false))
        {
            ballScript.madeShot = true;
            SoundManager.PlaySound("Made Shot");
            StartCoroutine(ballScript.MadeShotDelay());
        }
    }
}
