using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public static string resultTextToString;
    public Text ResultText;

    void Start()
    {
        ResultText.text = resultTextToString;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("PlayGame", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
