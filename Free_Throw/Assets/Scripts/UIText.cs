using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    public Text levelText;
    public int level = 1;

    public int numOfBalls = 5;

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = "" + level;
    }

    public void AddLevel()
    {
        level++;
        levelText.text = "" + level;
    }

    void LevelResult()
    {
        if (level > 4)
        {
            EndScene.resultTextToString = "You WIN! You cookin' like Steph";
            SceneManager.LoadScene("ResultMenu");
        }
        else if ((level == 4) && (numOfBalls == 0))
        {
            EndScene.resultTextToString = "Almost there, you were kinda hot like Dame";
            SceneManager.LoadScene("ResultMenu");
        }
        else if ((level == 3) && (numOfBalls == 0))
        {
            EndScene.resultTextToString = "Aw come on Kobe, show me that Mamba mentality";
            SceneManager.LoadScene("ResultMenu");
        }
        else if ((level == 2) && (numOfBalls == 0))
        {
            EndScene.resultTextToString = "Uh oh, gotta do more practice like Lebron";
            SceneManager.LoadScene("ResultMenu");
        }
        else if ((level == 1) && (numOfBalls == 0))
        {
            EndScene.resultTextToString = "You shootin' bricks? Man, you like Shaq dude";
            SceneManager.LoadScene("ResultMenu");
        }
    }

    void Update()
    {
        LevelResult();
    }
}
