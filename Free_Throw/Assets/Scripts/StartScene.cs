using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("PlayGame", LoadSceneMode.Single); // loads PlayGame scene
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game"); // quits application
        Application.Quit();
    }
}
