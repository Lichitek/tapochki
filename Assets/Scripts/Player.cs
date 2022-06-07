using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{

    Rigidbody2D rb;

    public float speed;
    public float jumpHeight;

    public Transform GroundCheck;


    public Main main;

    public bool key = false;
    public bool CanTP = true;
    public bool inWater = false;

    Animator anim;

    public int curHP;
    public int maxHP = 3;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    int coins = 0;

    bool isGrounded;
    bool isHit = false;
    bool isClimbing = false;
    bool canHit = true;

    public Image coinCounter;
    public Image coinCounterTens;
    public Sprite[] numbers = new Sprite[10];


    public bool[] canChange = { true, false, false, false, false };



    void Start() //при старте игры имеем:
    {
        rb = GetComponent<Rigidbody2D>(); //физ тело
        anim = GetComponent<Animator>(); //вмещает компонент аниматор типа анимации лол
        curHP = maxHP; //запас опред. кол-ва жизе
    }
    
    void Update() //во время
    {
        if (inWater && !isClimbing) //если в воде и не на лестнице
        {
            anim.SetInteger("State", 4); //анимка на плаванье
            isGrounded = true; //умеем прыгать (типа на земле) //нужен исграундет 
            if (Input.GetAxis("Horizontal") != 0)//если влево или вправо
            {
                Flip(); //поворот героя
            }
        }
        else
        {
            CheckGround(); //наша точка земли

            if (Input.GetAxis("Horizontal") == 0 && isGrounded && !isClimbing) //состояние покоя если на земле и не на лестнице
            {
                anim.SetInteger("State", 1); //подключение 1 анимации
            }

            else //ходьба
            {
                Flip(); //на анимацию

                if (isGrounded && !isClimbing) //если на земле и не на лестнице
                {
                    anim.SetInteger("State", 2); //переключаемся на вторую анимку 
                }
            }
        }

        for (int i = 0; i < hearts.Length; i++)//отображение хп
        {

            if (i < curHP)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;


            /*if (i < curHP)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;*/
        }


        //отображение кол-ва монет
        switch (coins%10)
        {
            case 0: coinCounter.sprite = numbers[0]; break;
            case 1: coinCounter.sprite = numbers[1]; break;
            case 2: coinCounter.sprite = numbers[2]; break;
            case 3: coinCounter.sprite = numbers[3]; break;
            case 4: coinCounter.sprite = numbers[4]; break;
            case 5: coinCounter.sprite = numbers[5]; break;
            case 6: coinCounter.sprite = numbers[6]; break;
            case 7: coinCounter.sprite = numbers[7]; break;
            case 8: coinCounter.sprite = numbers[8]; break;
            case 9: coinCounter.sprite = numbers[9]; break;
        }

        switch (coins /10)
        {
            case 0: coinCounterTens.enabled = false; break;
            case 1: { coinCounterTens.enabled = true; coinCounterTens.sprite = numbers[1]; break; }
            case 2: coinCounterTens.sprite = numbers[2]; break;
            case 3: coinCounterTens.sprite = numbers[3]; break;
            case 4: coinCounterTens.sprite = numbers[4]; break;
            case 5: coinCounterTens.sprite = numbers[5]; break;
            case 6: coinCounterTens.sprite = numbers[6]; break;
            case 7: coinCounterTens.sprite = numbers[7]; break;
            case 8: coinCounterTens.sprite = numbers[8]; break;
            case 9: coinCounterTens.sprite = numbers[9]; break;
        }


    }

    void FixedUpdate() //постоянные обновления по кадрам на анимку движения
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y); //ходьба
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //прыжок
            rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse); //задаем импульс

    }

    void Flip() //на разворот изображения
    {
        if (Input.GetAxis("Horizontal") > 0) //туда
            transform.localRotation = Quaternion.Euler(0, 0, 0); //собсна смена положения по оси у
        
        if (Input.GetAxis("Horizontal") < 0) //сюда
            transform.localRotation = Quaternion.Euler(0, 180, 0); //собсна смена положения по оси у, ток в другую сторону
    }

    void CheckGround() //проверка нахождения героя на земле
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, 0.2f); //массивы

        isGrounded = colliders.Length > 1; //длинна массива тип

        if (!isGrounded && !isClimbing) //если не на земле(прыгает) и не на лестнице, то анимка прыжка 
        {
            anim.SetInteger("State", 3); //переключаемся на 3-ю анимацию
        }
    }

    public void RecountHP(int deltaHP) //пересчитывание жизней
    {

        if (deltaHP < 0 && canHit) //на изменение цвета вызов
        {
            curHP = curHP + deltaHP; //всего жизней = тек.жизнь + изменения (+ на - дает -)

            StopCoroutine(OnHit()); //стопаем карутину на смену цвета

            canHit = false;

            isHit = true; //типа ударяемся

            StartCoroutine(OnHit()); //начало карутины на смену цвета во время удара
        }

        else if (deltaHP > 0)
        {
            curHP += deltaHP;
        }

        else if (curHP <= 1) //если мы потратили жизни
        {
            curHP = 0;
            GetComponent<BoxCollider2D>().enabled = false; //выключаем коллайдер
            Invoke("Lose", 3f); //падаем 3 сек
        }

        if (curHP >= maxHP)
            curHP = maxHP;
    }

    IEnumerator OnHit() //меняем цвет во время удара //карутина 
    {
        if (isHit) //в красный
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, GetComponent<SpriteRenderer>().color.g - 0.04f, GetComponent<SpriteRenderer>().color.b - 0.04f); //а тут пишем как цвета меняются с каким периодом
        }

        else //идем сюда потом после 2 проверки
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, GetComponent<SpriteRenderer>().color.g + 0.04f, GetComponent<SpriteRenderer>().color.b + 0.04f); //а тут пишем как цвета меняются с каким периодом
        }

        if (GetComponent<SpriteRenderer>().color.g == 1) //и так по кругу твою подругу суку
        {
            StopCoroutine(OnHit()); //СТОПАРИМ ЧТОБЫ НЕ БЫЛО ПЕРЕГРУЗОК, ТЕЛКА УМРЕТ!!
            canHit = true;
        }

        if (GetComponent<SpriteRenderer>().color.g <= 0) //достигли - меняем
        {
            isHit = false;
        }

        yield return new WaitForSeconds(0.02f); //период (1сек/количество кадров fps)

        StartCoroutine(OnHit()); //начинаем карутину
    }

    void Lose()
    {
        main.GetComponent<Main>().Lose(); //обращаемся к скрипту с жизнями
    }

    private void OnTriggerEnter2D(Collider2D collision) //метод на телепорт 
    {
        if(collision.gameObject.tag == "key") //если столкнулись с ключем
        {
            Destroy(collision.gameObject); //удалили ключ
            key = true; //типа терь он у нас в кармане
        }

        if(collision.gameObject.tag == "Door")
        {
            if(collision.gameObject.GetComponent<Door>().isOpen && CanTP) //если дверь открыта и мы можем тпшиться
            {
                collision.gameObject.GetComponent<Door>().Teleport(gameObject); //тпшимся
                CanTP = false; //не можем терь снова тпшиться
                StartCoroutine(TPwait()); //начинаем карутину
            }
            else if(key)
            {
                collision.gameObject.GetComponent<Door>().Unlock(); //прост открыли дверь
            }
        }
        
        if (collision.gameObject.tag == "Coin") //если столкнулись с ключем
        {
            coins++; //(ведем счет монет)
            Destroy(collision.gameObject); //удалили ключ
            print("Количество монет: " + coins); //добавили монету в карман (счетчик на экране)
        }

        if (collision.gameObject.tag == "Heart") //если столкнулись с сердцем
        {
            RecountHP(1); //(ведем счет жизни)
            Destroy(collision.gameObject); //удалили сердце

        }

    }

    IEnumerator TPwait() //карутина на телепорт
    {
        yield return new WaitForSeconds(1f); //ждем сек
        CanTP = true; //можем снова тпшиться
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder") //если контакт с триггером лектницы
        {
            isClimbing = true;
            rb.bodyType = RigidbodyType2D.Kinematic;
            if (Input.GetAxis("Vertical") == 0)
            {
                anim.SetInteger("State", 5); //анимация номер 5, когда чел просто на леснице неподвижно
            }
            else
            {
                transform.Translate(Vector3.up * Input.GetAxis("Vertical") * speed * 0.5f * Time.deltaTime); //меняет позицию// в аргументах верктор направления и длинну//инпут гет аксис - кнопки на клаве
                anim.SetInteger("State", 6); //включение анимации карабканья по лестнице
            }
        }
    }








    IEnumerator Invis(SpriteRenderer spr, float time) //карутина исчезновения кристаллов
    {
        spr.color = new Color(1f, 1f, 1f, spr.color.a - time * 2); //обращаемся к прозрачности объекта 
        yield return new WaitForSeconds(time); //расстояние между соседними кадрами, время выполнения выцветания кристалла
        
        if(spr.color.a > 0) //если кристалл не исчез, запускаем карутину снова
        {
            StartCoroutine(Invis(spr, time)); //старт карутины
        }
    }
}
