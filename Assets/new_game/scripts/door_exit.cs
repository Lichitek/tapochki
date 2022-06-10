using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door_exit : MonoBehaviour
{
    bool playerInRange = false;

    public GameObject hintBox;



    void Update()
    {

        if (playerInRange)
        {
            hintBox.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            hintBox.SetActive(false);
        }
    }
}
