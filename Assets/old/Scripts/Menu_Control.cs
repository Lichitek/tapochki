using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Control : MonoBehaviour
{

    public Canvas mainMenu;
    public Canvas controls;

    private void Start()
    {
        controls.enabled = false;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ControlsOn()
    {
        mainMenu.enabled = false;
        controls.enabled = true;
    }    

    public void MenuOn()
    {
        controls.enabled = false;
        mainMenu.enabled = true;
    }

}
