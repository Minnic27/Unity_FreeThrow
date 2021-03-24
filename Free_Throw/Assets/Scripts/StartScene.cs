using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    
    public void StartGame()
    {
        Debug.Log("change scene");
          SceneManager.LoadScene("PlayGame", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
