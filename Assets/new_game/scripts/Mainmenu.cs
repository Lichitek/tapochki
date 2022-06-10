using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuiteGame()
    {
        Application.Quit();
    }
    public void Continue()
    {
        string level = dataBank.nameLv;
        if(level!="")
        {
            SceneManager.LoadScene(level);
        }

    }

}
