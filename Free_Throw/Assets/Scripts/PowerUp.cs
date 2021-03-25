using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private Image imagePowerUp;
    [SerializeField]
    private TMP_Text textPowerAmt;

    private bool isPowerUp = false;
    private bool isDirectionUp = true;
    private float amtPower = 0.0f;
    private float powerSpeed = 100.00f;

    void Update()
    {
        if(isPowerUp)
        {
            PowerActive();
        }

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

    void PowerActive()
    {
        /*if(isDirectionUp)
        {
            amtPower += Time.deltaTime * powerSpeed;
            if(amtPower > 100)
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
        imagePowerUp.fillAmount = (0.483f - 0.25f) * amtPower / 100.0f + 0.25f;*/
    }

    public void StarPowerUp()
    {
        isPowerUp = true;
        amtPower = 0.0f;
        isDirectionUp = true;
        
    }

    public void EndPowerUp()
    {
        isPowerUp = false;
        
    }
}
