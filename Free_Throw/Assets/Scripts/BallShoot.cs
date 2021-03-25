using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShoot : MonoBehaviour
{
    public GameObject ball;
    public GameObject player;
    public GameObject mainCamera;
    private GameObject spawnedBall;

    public float ballThrowingForce;

    private Vector3 cameraAngle = new Vector3(0, -0.52f, 0.35f);
    private Vector3 shootingArc = new Vector3(0, 120, 50);
    private Vector3 playerPos;
    private Vector3 ballPos;

    private int randomIntZ;
    private int randomIntY;

    private bool holdingBall = true;
    public bool madeShot = false;
    public bool missedShot = false;

    public UIText uText;


    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();
        playerPos = player.transform.position;
        ballPos = playerPos;

        uText = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIText>(); // access UIText script


    }

    // Update is called once per frame
    void Update()
    {
        if (holdingBall)
        {
            if (Input.GetMouseButtonDown(0))
            {
                spawnedBall.GetComponent<Rigidbody>().useGravity = true;
                spawnedBall.GetComponent<Rigidbody>().AddForce(shootingArc.normalized * ballThrowingForce);
                holdingBall = false;
            }
        }

        //LevelResult();

    }


    public void SpawnBall()
    {
        holdingBall = true;
        Debug.Log("Balls Left: " + uText.numOfBalls);

        if (missedShot == false)
        {
            UpdatePosition();
        }
        
        spawnedBall = Instantiate(ball, ballPos, ball.transform.rotation) as GameObject;
        spawnedBall.GetComponent<Rigidbody>().useGravity = false;

        missedShot = false;
    }

    public IEnumerator MadeShotDelay()
    {
        Debug.Log("SHOOT!");
        yield return new WaitForSeconds(3);
        Destroy(spawnedBall);
        uText.AddLevel();
        madeShot = false;
        SpawnBall();
    }

    public IEnumerator MissedShotDelay()
    {
        Debug.Log("MISSED!");
        yield return new WaitForSeconds(3);
        Destroy(spawnedBall);
        madeShot = false;
        missedShot = true;
        uText.numOfBalls--;
        SpawnBall();
    }


    void UpdatePosition()
    {
        if (uText.level == 1)
        {
            ballPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            player.transform.position = ballPos;
            mainCamera.transform.position = ballPos - cameraAngle;
            ballThrowingForce = 200f;
        }
        else if (uText.level == 2)
        {
            ballPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 0.4f);
            player.transform.position = ballPos;
            mainCamera.transform.position = ballPos - cameraAngle;
            ballThrowingForce = 240f;
        }
        else if (uText.level == 3)
        {
            ballPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 0.5f);
            player.transform.position = ballPos;
            mainCamera.transform.position = ballPos - cameraAngle;
            ballThrowingForce = 265f;
        }
        else if (uText.level == 4)
        {
            ballPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 0.6f);
            player.transform.position = ballPos;
            mainCamera.transform.position = ballPos - cameraAngle;
            ballThrowingForce = 300f;
        }
    }


}
