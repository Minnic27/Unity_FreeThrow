using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallShoot : MonoBehaviour
{

    [SerializeField]
    private Image imagePowerUp;

    private bool isDirectionUp = true;
    private float amtPower = 0.0f;
    private float powerSpeed = 100.00f;

    public GameObject ball;
    public GameObject player;
    public GameObject mainCamera;
    private GameObject spawnedBall;

    private float ballThrowingForce;
    private float currentThrowingForce;

    private Vector3 cameraAngle = new Vector3(0, -0.27f, 0.37f);
    private Vector3 shootingArc = new Vector3(0, 120, 50);
    private Vector3 playerPos;
    private Vector3 ballPos;

    private int randomIntZ;
    private int randomIntY;

    private bool holdingBall = true;
    public bool madeShot = false;
    public bool missedShot = false;
    private bool btnClicked = false;

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
        if ((holdingBall) && (btnClicked))
        {
            spawnedBall.GetComponent<Rigidbody>().useGravity = true;
            spawnedBall.GetComponent<Rigidbody>().AddForce(shootingArc.normalized * ballThrowingForce);
            holdingBall = false;
           
        }

        PowerMeter();

    }


    public void SpawnBall()
    {
        
        holdingBall = true;

        if (missedShot == false)
        {
            UpdatePosition();
        } else
        {
            ballThrowingForce = currentThrowingForce;
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
        btnClicked = false;
        amtPower = 0.0f;
        SpawnBall();
    }

    public IEnumerator MissedShotDelay()
    {
        Debug.Log("MISSED!");
        yield return new WaitForSeconds(3);
        Destroy(spawnedBall);
        madeShot = false;
        missedShot = true;
        uText.DecreaseNumberOfBalls();
        btnClicked = false;
        amtPower = 0.0f;
        SpawnBall();
    }


    void UpdatePosition()
    {
        if (uText.level == 1)
        {
            ballPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            player.transform.position = ballPos;
            mainCamera.transform.position = ballPos - cameraAngle;
            ballThrowingForce = 2.5f;
        }
        else if (uText.level == 2)
        {
            ballPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 0.4f);
            player.transform.position = ballPos;
            mainCamera.transform.position = ballPos - cameraAngle;
            ballThrowingForce = 3f;
        }
        else if (uText.level == 3)
        {
            ballPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 0.5f);
            player.transform.position = ballPos;
            mainCamera.transform.position = ballPos - cameraAngle;
            ballThrowingForce = 3.5f;
        }
        else if (uText.level == 4)
        {
            ballPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 0.6f);
            player.transform.position = ballPos;
            mainCamera.transform.position = ballPos - cameraAngle;
            ballThrowingForce = 4f;
        }
    }

    void PowerMeter ()
    {
        if (!btnClicked)
        {
            if (isDirectionUp)
            {
                amtPower += Time.deltaTime * powerSpeed;
                if (amtPower > 100)
                {
                    isDirectionUp = false;
                    amtPower = 100.0f;
                }
            }
            else
            {
                amtPower -= Time.deltaTime * powerSpeed;
                if (amtPower < 0)
                {
                    isDirectionUp = true;
                    amtPower = 0.0f;
                }
            }
            imagePowerUp.fillAmount = (0.483f - 0.25f) * amtPower / 100.0f + 0.25f;
        }
        
    }

    public void ShootButton ()
    {
        currentThrowingForce = ballThrowingForce;
       
        ballThrowingForce = ballThrowingForce * amtPower;
        btnClicked = true;
    }

}
