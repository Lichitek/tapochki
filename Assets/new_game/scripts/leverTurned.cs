using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leverTurned : MonoBehaviour
{
    bool playerInRange=false;
    bool turnSlab=false;

    /*public GameObject hintBox;
    public Text hintText;
    public string hint;*/

    public GameObject slab;
    public Sprite turnOff;

    public float speed;
    public int startPoint;
    public Transform[] points;

    private int i;

    private void Start()
    {
        slab.GetComponent<moovingPlatform>().speed = 0f;

    }

    void Update()
    {
        //hintBox.transform.localPosition = new Vector2(slab.transform.localPosition.x, slab.transform.localPosition.y + 75);
        /* if (playerInRange)
        {
        //hintBox.SetActive(true);
        }*/
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && !turnSlab)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = turnOff;
            //hintBox.SetActive(false);
            turnSlab = true;
            slab.GetComponent<moovingPlatform>().speed = 2f;
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
            //hintBox.SetActive(false);
        }
    }
}
