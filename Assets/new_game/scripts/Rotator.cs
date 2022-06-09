using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 100.0f;
    public GameObject laser;
    bool playerInRange = false;

    void Update()
    {
        float rotation = 0;
        if (Input.GetKey(KeyCode.Q) && playerInRange)
        {
            rotation += rotationSpeed;
        }
        else if (Input.GetKey(KeyCode.E) && playerInRange)
        {
            rotation -= rotationSpeed;


        }
        
        //float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        rotation *= Time.deltaTime;

        // Rotate around our y-axis
        laser.transform.Rotate(0, 0, rotation);
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
            //hintBox.SetActive(false);
        }
    }
}
