using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;

    public GameObject hintBox;
    public Text hintText;
    public string hint;

    public GameObject target;

    public Transform obj;
    public Vector3 hoh;


    private void Start()
    {
        
    }

    void Update()
    {
        if(playerInRange)
        {
            Vector2 pos = this.gameObject.transform.position;
            hintBox.transform.localPosition = new Vector2(target.transform.localPosition.x, target.transform.localPosition.y + 75); ; //53.7f *(pos + new Vector2(0, 1.5f));//Поменять позицию
            if (dialogBox.activeInHierarchy)
            {
                hintBox.SetActive(false);
            }
            else
            {
                hintBox.SetActive(true);
                hintText.text = hint;
            }
        }
        if(Input.GetKeyDown(KeyCode.E)&&playerInRange)
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
            hintBox.SetActive(false);
        }
    }
}
