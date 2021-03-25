using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShoot : MonoBehaviour
{
    public GameObject ball;
    public GameObject player;
    public GameObject mainCamera;
    private GameObject spawnedBall;

    private float ballThrowingForce;

    private Vector3 cameraAngle = new Vector3(0, -0.52f, 0.35f);
    private Vector3 shootingArc;
    private Vector3 playerPos;
    private Vector3 ballPos;

    private int randomIntZ;
    private int randomIntY;

    private bool holdingBall;

    private int level = 1;
    private int numOfBalls = 5;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();

        playerPos = player.transform.position;
        ballPos = playerPos;

        shootingArc = new Vector3(0, 120, 50);


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
                numOfBalls--;
                
            }
        }

        LevelResult();

    }


    public void SpawnBall()
    {
        holdingBall = true;
        Debug.Log("Balls Left: " + numOfBalls);
        Debug.Log("Level: " + level);
        Debug.Log("Level: " + level);
        UpdatePosition();
        spawnedBall = Instantiate(ball, ballPos, ball.transform.rotation) as GameObject;
        spawnedBall.GetComponent<Rigidbody>().useGravity = false;
    }

    public IEnumerator Delay()
    {
        Debug.Log("SHOOT!");
        yield return new WaitForSeconds(3);
        Destroy(spawnedBall);
        level++;
        SpawnBall();
    }

    void UpdatePosition()
    {
        if (level == 1)
        {
            ballPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            player.transform.position = ballPos;
            mainCamera.transform.position = ballPos - cameraAngle;
            ballThrowingForce = 200f;
        }
        else if (level == 2)
        {
            ballPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 0.4f);
            player.transform.position = ballPos;
            mainCamera.transform.position = ballPos - cameraAngle;
            ballThrowingForce = 240f;
        }
        else if (level == 3)
        {
            ballPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 0.5f);
            player.transform.position = ballPos;
            mainCamera.transform.position = ballPos - cameraAngle;
            ballThrowingForce = 265f;
        }
        else if (level == 4)
        {
            ballPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 0.6f);
            player.transform.position = ballPos;
            mainCamera.transform.position = ballPos - cameraAngle;
            ballThrowingForce = 300f;
        }
    }

    void LevelResult()
    {
        if (level == 5)
        {
            Debug.Log("You WIN! You cookin' like Steph");
        }
        else if ((level == 4) && (numOfBalls == 0))
        {
            Debug.Log("Almost there, you were kinda hot like Dame");
        }
        else if ((level == 3) && (numOfBalls == 0))
        {
            Debug.Log("Aw come on Kobe, show me that Mamba mentality");
        }
        else if ((level == 2) && (numOfBalls == 0))
        {
            Debug.Log("Uh oh, gotta do more practice like Lebron");
        }
        else if ((level == 1) && (numOfBalls == 0))
        {
            Debug.Log("You shootin' bricks? Man, you like Shaq dude");
        }
    }

    
}
