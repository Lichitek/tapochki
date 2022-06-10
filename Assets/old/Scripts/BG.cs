using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    float length, startpos;
    float dist;
    float temp;
    public GameObject cam;

    public float parallaxEffect;

    void Start()
    {
        startpos = transform.position.x; //записываем в позицию переменную
        length = GetComponent<SpriteRenderer>().bounds.size.x; //запись по оси х
    }

    //ЧЕМ ВЫШЕ ПАРАЛЛАКС ЭФФЕКТ, ТЕМ БОЛЬШЕ БУДЕТ РАССИНХРОНА МЕЖДУ ДВИЖЕНИЯМИ ФОНА И КАМЕРЫ
    //1 = ФОН ДВИЖЕТСЯ С КАМЕРОЙ
    //0 = ФОН ДВИЖЕТСЯ САМ ПО СЕБЕ (МАКС ПАРАЛЛАКС)

    void Update()
    {
        temp = cam.transform.position.x * (1 - parallaxEffect); //для корректной работы фона временная переменная

        dist = cam.transform.position.x * parallaxEffect; //паралакс

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z); //сдвиг фона относ. камеры

        if (temp > startpos + length) //проверка отклонения камеры
        {
            startpos += length;
        }

        else if (temp < startpos - length)
        {
            startpos -= length;
        }
    }
}
