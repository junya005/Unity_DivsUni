using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void GameStartinTitle()
    {
        if(GameSettings.setting_tutorial)
        {
            SceneManager.LoadScene("Tutorial");
        }
        else
        {
            SceneManager.LoadScene("Main");
        }
    }

    public void GameEnd()
    {
        SceneManager.LoadScene("Title");
    }

    public void ProgramEnd()
    {
        Application.Quit();
    }
}
