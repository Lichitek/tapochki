using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 100.0f;
    public GameObject laser;
    public GameObject hint1;
    public GameObject hint2;
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

        rotation *= Time.deltaTime;

        laser.transform.Rotate(0, 0, rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            hint1.SetActive(true);
            hint2.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            hint1.SetActive(false);
            hint2.SetActive(false);
        }
    }
}
