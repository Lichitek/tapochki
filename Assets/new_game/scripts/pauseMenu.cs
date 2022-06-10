using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject reset;
    public GameObject resum;


    private void Start()
    {
        dataBank.nameLv = SceneManager.GetActiveScene().name;    
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && dataBank.isgame)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        else if(!dataBank.isgame)
        {
            pauseMenuUI.SetActive(true);
            reset.SetActive(true);
            resum.SetActive(false);
        }


    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        reset.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void Rezet()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        dataBank.isgame = true;
        pauseMenuUI.SetActive(false);
    }
}