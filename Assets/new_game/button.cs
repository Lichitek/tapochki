using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public GameObject[] block; //массив на эл-ты, которые будут исчезать при нажатии кнопки
    public Sprite btnDown; //спрайт кнопки, когда она вкл
    public GameObject butTon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision) //метод 
    {
        if (collision.gameObject.tag == "mark") //если объект столкновения коробка
        {

            butTon.GetComponent<SpriteRenderer>().sprite = btnDown; //присваиваем новый спрайт
            butTon.GetComponent<BoxCollider2D>().enabled = false; //выключаем коллайдер, когда кнопка вкл

            foreach (GameObject obj in block) //цикл для каждого объекта ля удаления, после вкл кнопки
            {
                Destroy(obj); //удаляем
            }
        }
    }
}
