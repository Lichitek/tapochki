using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button1 : MonoBehaviour
{
    public GameObject[] block; //массив на эл-ты, которые будут исчезать при нажатии кнопки
    public Sprite btnDown; //спрайт кнопки, когда она вкл
    public GameObject butTon;

    private void OnCollisionEnter2D(Collision2D collision) //метод 
    {

        if (collision.gameObject.tag == "mark") //если объект столкновения коробка
        {

            butTon.GetComponent<SpriteRenderer>().sprite = btnDown; //присваиваем новый спрайт
            butTon.GetComponent<BoxCollider2D>().enabled = false; //выключаем коллайдер, когда кнопка вкл

            foreach (GameObject obj in block) //цикл для каждого объекта ля удаления, после вкл кнопки
            {
                obj.SetActive(true);
            }
        }
        if (collision.gameObject.tag == "block") //если объект столкновения коробка
        {

            GetComponent<SpriteRenderer>().sprite = btnDown; //присваиваем новый спрайт
            GetComponent<BoxCollider2D>().enabled = false; //выключаем коллайдер, когда кнопка вкл
            collision.gameObject.GetComponent<Rigidbody2D>().Sleep();

            foreach (GameObject obj in block) //цикл для каждого объекта ля удаления, после вкл кнопки
            {
                obj.SetActive(true);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mark") //если объект столкновения коробка
        {

            butTon.GetComponent<SpriteRenderer>().sprite = btnDown; //присваиваем новый спрайт
            butTon.GetComponent<BoxCollider2D>().enabled = false; //выключаем коллайдер, когда кнопка вкл

            foreach (GameObject obj in block) //цикл для каждого объекта ля удаления, после вкл кнопки
            {
                obj.SetActive(true);
            }
        }
        if (collision.gameObject.tag == "block") //если объект столкновения коробка
        {

            GetComponent<SpriteRenderer>().sprite = btnDown; //присваиваем новый спрайт
            GetComponent<BoxCollider2D>().enabled = false; //выключаем коллайдер, когда кнопка вкл
            collision.gameObject.GetComponent<Rigidbody2D>().Sleep();

            foreach (GameObject obj in block) //цикл для каждого объекта ля удаления, после вкл кнопки
            {
                obj.SetActive(true);
            }
        }
    }
}
