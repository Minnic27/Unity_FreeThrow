using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public BallShoot ballScript;

    void Start()
    {
        ballScript = GameObject.FindGameObjectWithTag("Spawn").GetComponent<BallShoot>();
    }

    void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.tag == "Ball") && (ballScript.madeShot == false))
        {
            SoundManager.PlaySound("Missed Shot");
            ballScript.madeShot = true;
            StartCoroutine(ballScript.MissedShotDelay());
        }
        
    }
}
